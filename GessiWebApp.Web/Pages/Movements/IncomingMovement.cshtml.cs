// GessiWebApp.Web/Pages/Movements/IncomingMovement.cshtml.cs
using GessiWebApp.API.DTOs;
using GessiWebApp.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace GessiWebApp.Web.Pages.Movements
{
    public class IncomingMovementModel : PageModel
    {
        private readonly IMovementApiService _movementService;

        public IncomingMovementModel(IMovementApiService movementService)
        {
            _movementService = movementService;
        }

        [BindProperty]
        public MovementCreateDto Movement { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _movementService.CreateIncomingMovementAsync(Movement);

            return RedirectToPage("./Index");
        }
    }
}