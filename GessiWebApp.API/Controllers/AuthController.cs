using API.Interfaces;
using GessiWebApp.API.Services.Interfaces;
using GessiWebApp.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;
using BCrypt.Net;
using System;
using System.Threading.Tasks;
using GessiWebApp.Shared.Enums;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly ITokenService _tokenService;
    private readonly IEmailService _emailService;

    public AuthController(IUserService userService, ITokenService tokenService, IEmailService emailService)
    {
        _userService = userService;
        _tokenService = tokenService;
        _emailService = emailService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var user = new User
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            Email = model.Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.Password),
            Role = UserRole.Operatore,  // Utilizza l'enum per il ruolo
            IsEmailConfirmed = false,
            EmailConfirmationToken = Guid.NewGuid().ToString()
        };

        await _userService.CreateUserAsync(user);
        await _emailService.SendConfirmationEmailAsync(user.Email, user.EmailConfirmationToken);

        return Ok(new { message = "Registrazione effettuata con successo. Controlla la tua email per confermare l'account." });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginModel model)
    {
        var user = await _userService.GetUserByEmailAsync(model.Email);

        if (user == null || !BCrypt.Net.BCrypt.Verify(model.Password, user.PasswordHash))
            return Unauthorized(new { message = "Email o password non validi." });

        if (!user.IsEmailConfirmed)
            return BadRequest(new { message = "Email non confermata. Controlla la tua casella di posta." });

        var token = _tokenService.GenerateJwtToken(user);

        return Ok(new { token });
    }

    [HttpGet("confirm-email")]
    public async Task<IActionResult> ConfirmEmail(string email, string token)
    {
        var user = await _userService.GetUserByEmailAsync(email);

        if (user == null || user.EmailConfirmationToken != token)
            return BadRequest(new { message = "Token di conferma non valido." });

        user.IsEmailConfirmed = true;
        user.EmailConfirmationToken = null;
        await _userService.UpdateUserAsync(user);

        return Ok(new { message = "Email confermata con successo." });
    }
}
