using GessiWebApp.API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;


[Authorize(Roles = "Amministratore")]
[ApiController]
[Route("api/[controller]")]
public class UserManagementController : ControllerBase
{
    private readonly IUserService _userService;

    public UserManagementController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await _userService.GetAllUsersAsync();
        return Ok(users);
    }

    [HttpPut("{id}/role")]
    public async Task<IActionResult> ChangeUserRole(int id, ChangeRoleModel model)
    {
        var user = await _userService.GetUserByIdAsync(id);
        if (user == null)
            return NotFound();

        user.Role = model.NewRole;
        await _userService.UpdateUserAsync(user);

        return Ok(new { message = "Ruolo utente aggiornato con successo." });
    }

    
}