using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DigitalAccOpening.Pages.Customer
{
    public class FrontPageModel : PageModel
    {
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            return RedirectToPage("gmail");
        }
    }
}
