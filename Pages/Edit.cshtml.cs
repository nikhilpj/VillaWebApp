using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VillaWebApp.Models;

namespace VillaWebApp.Pages
{
    public class EditModel : PageModel
    {
        public Villa villa {  get; set; }
        public void OnGet()
        {
        }
    }
}
