using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DigitalAccOpening.Pages.Practice
{
    public class IndexModel : PageModel
    {
        public string name="faisal";

        public void OnGet()
        {
        }
        public IActionResult o()
        {
            TempData["Name"]=name;
            return RedirectToPage("Index1");

        }
    }
}
