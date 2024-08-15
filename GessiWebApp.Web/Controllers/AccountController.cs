using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Web.ViewModels;
using GessiWebApp.Shared.Models;
using Shared.Responses;
using Microsoft.AspNetCore.Authorization;
using Shared.Models;
using Web.Services;

namespace Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IApiService _apiService;

        public AccountController(IApiService apiService)
        {
            _apiService = apiService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                var authResponse = await _apiService.PostAsync<AuthResponse>("/api/auth/login", model);

                if (authResponse != null)
                {
                    Response.Cookies.Append("AuthToken", authResponse.Token, new CookieOptions
                    {
                        HttpOnly = true,
                        Secure = Request.IsHttps,
                        SameSite = SameSiteMode.Strict
                    });

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Errore nella risposta di autenticazione.");
                    return View(model);
                }
            }
            catch (HttpRequestException ex)
            {
                ModelState.AddModelError(string.Empty, "Errore nella comunicazione con il server: " + ex.Message);
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                var response = await _apiService.PostAsync<string>("/api/auth/register", model);
                return RedirectToAction("RegisterConfirmation");
            }
            catch (HttpRequestException ex)
            {
                ModelState.AddModelError(string.Empty, "Errore nella comunicazione con il server: " + ex.Message);
                return View(model);
            }
        }

        public IActionResult RegisterConfirmation()
        {
            return View();
        }

        [Authorize]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("AuthToken");
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await _apiService.PostAsync<string>("/api/auth/forgot-password", model);
                return View("ForgotPasswordConfirmation");
            }
            catch (HttpRequestException ex)
            {
                ModelState.AddModelError(string.Empty, "Errore nella comunicazione con il server: " + ex.Message);
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult ResetPassword(string token, string email)
        {
            var model = new ResetPasswordViewModel { Token = token, Email = email };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await _apiService.PostAsync<string>("/api/auth/reset-password", model);
                return RedirectToAction("ResetPasswordConfirmation");
            }
            catch (HttpRequestException ex)
            {
                ModelState.AddModelError(string.Empty, "Errore nella comunicazione con il server: " + ex.Message);
                return View(model);
            }
        }

        public IActionResult ResetPasswordConfirmation()
        {
            return View();
        }
    }
}