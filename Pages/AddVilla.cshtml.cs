using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VillaWebApp.Models;
using VillaWebApp.Services;

namespace VillaWebApp.Pages
{
    public class AddVillaModel : PageModel
    {
        private readonly ApiService _apiService;

        public AddVillaModel(ApiService apiService)
        {
            _apiService = apiService;
        }

        public Villa Villa { get; set; }
      

        public async Task<IActionResult> OnPost(Villa Villa)
        {
            var created = await _apiService.PostVillasAsync(Villa);
           
            if (created != null)
            {
                // Redirect to the Home page or any other page after a successful submission
                return RedirectToPage("/Home");

            }

            return Page();

        }
    }
}
