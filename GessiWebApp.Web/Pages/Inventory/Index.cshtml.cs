// GessiWebApp.Web/Pages/Inventory/Index.cshtml.cs
using GessiWebApp.API.DTOs;
using GessiWebApp.Web.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GessiWebApp.Web.Pages.Inventory
{
    public class IndexModel : PageModel
    {
        private readonly IMaterialApiService _materialService;

        public IndexModel(IMaterialApiService materialService)
        {
            _materialService = materialService;
        }

        public IEnumerable<MaterialDto> Materials { get; set; }

        public async Task OnGetAsync()
        {
            Materials = await _materialService.GetAllMaterialsWithInventoryAsync();
        }
    }
}