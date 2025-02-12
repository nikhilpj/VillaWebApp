using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VillaWebApp.Models;
using VillaWebApp.Services;

namespace VillaWebApp.Pages
{
    public class EditModel : PageModel
    {
        private readonly ApiService _apiService;
        [BindProperty]
        public Villa villa {  get; set; }

        public EditModel(ApiService apiService)
        {
            _apiService = apiService;
        }
        public async Task OnGet(int id)
        {
            villa = await _apiService.GetVilla(id);
        }

        public async Task<IActionResult> OnPost()
        {
           
            
                var status = await _apiService.UpdateVilla(villa.Id, villa);
                Console.WriteLine("status is", status);
                if (status)
                {
                    return RedirectToPage("/Home");
                }
            
             
            return Page();
        }
    }
}
