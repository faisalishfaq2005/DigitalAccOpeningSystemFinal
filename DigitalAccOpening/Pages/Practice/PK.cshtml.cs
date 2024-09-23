using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DigitalAccOpening.Pages.Practice
{
    public class PKModel : PageModel
    {
        public IActionResult OnPostYes()
        {
            return RedirectToPage("/Customer/gmail");
        }
        public IActionResult OnPostNo()
        {
            return RedirectToPage("sum");
        }
    }
}
