using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DigitalAccOpening.Pages.Customer
{
    public class AccountForPersonInfoModel : PageModel
    {
        public void OnGet()
        {
        }
        public IActionResult OnPostMyself()
        {
            return RedirectToPage("/Customer/CnicInfo");
        }
        public IActionResult OnPostSomeoneElse()
        {
            return RedirectToPage("ServiceNotGivenPage");
        }
    }
}
