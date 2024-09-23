using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DigitalAccOpening.Pages.Customer
{
    public class PakistaniNationalInfoModel : PageModel
    {
        public IActionResult OnPostYes()
        {
            return RedirectToPage("/Customer/AccountForPersonInfo");
        }
        public IActionResult OnPostNo()
        {
            return RedirectToPage("ServiceNotGivenPage");
        }
    }
}
