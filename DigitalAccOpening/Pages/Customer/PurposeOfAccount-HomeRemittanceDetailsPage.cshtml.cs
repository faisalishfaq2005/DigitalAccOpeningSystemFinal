using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DigitalAccOpening.Pages.Customer
{
    public class PurposeOfAccount_HomeRemittanceDetailsPageModel : PageModel
    {
        [BindProperty]
        public string fundprovider { get; set; }

        [BindProperty]
        public string fundprovidername { get; set; }

        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
           return RedirectToPage("TypeOfBankingInfo");
        }
    }
}
