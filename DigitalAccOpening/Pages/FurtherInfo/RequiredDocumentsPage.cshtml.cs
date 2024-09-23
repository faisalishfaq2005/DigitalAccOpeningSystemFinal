using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DigitalAccOpening.Pages.FurtherInfo
{
    public class RequiredDocumentsPageModel : PageModel
    {
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            return RedirectToPage("PersonalInfoPage");
        }
    }
}
