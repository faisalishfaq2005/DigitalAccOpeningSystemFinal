using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DigitalAccOpening.Pages.Practice
{
    public class Index1Model : PageModel
    {
        public string classs = "uni";
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            TempData["Class"] = classs;
            TempData.Keep("Name");
            return RedirectToPage("sum");
        }
    }
}
