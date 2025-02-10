using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualBasic;
using VillaWebApp.Models;
using VillaWebApp.Services;

namespace VillaWebApp.Pages
{
    public class HomeModel : PageModel
    {
        private readonly ApiService _apiService;
        public List<Villa> villas {  get; set; }

        public HomeModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task OnGetAsync()
        {
            villas = await _apiService.GetVillasAsync();
        }
        
    }
}
