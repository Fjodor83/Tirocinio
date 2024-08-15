// GessiWebApp.Web/Pages/Missions/Complete.cshtml.cs
using GessiWebApp.API.DTOs;
using GessiWebApp.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace GessiWebApp.Web.Pages.Missions
{
    public class CompleteModel : PageModel
    {
        private readonly IMissionApiService _missionService;

        public CompleteModel(IMissionApiService missionService)
        {
            _missionService = missionService;
        }

        [BindProperty]
        public MissionDto Mission { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Mission = await _missionService.GetMissionByIdAsync(id);

            if (Mission == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _missionService.CompleteMissionAsync(Mission.Id);

            return RedirectToPage("./Index");
        }
    }
}