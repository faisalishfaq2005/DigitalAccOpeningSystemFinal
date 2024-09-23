using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DigitalAccOpening.Pages.Customer
{
    public class EmployementDetailsModel : PageModel
    {
        [BindProperty]
        public string employername {  get; set; }
        [BindProperty]
        public string designation { get; set; }

        [BindProperty]
        public string employementyears { get; set; }

        [BindProperty]
        public string basicpayscale { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            return RedirectToPage("TypeOfBankingInfo");
        }
    }
}
