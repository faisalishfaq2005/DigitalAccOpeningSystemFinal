using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DigitalAccOpening.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
        public IActionResult OnPostSA()
        {
            return RedirectToPage("/Customer/PakistaniNationalInfo");
            //return RedirectToPage("/FurtherInfo/LastPage");
            //return RedirectToPage("/FurtherInfo/VerifyEnteredDataPage");
        }
        public IActionResult OnPostRA()
        {
            return RedirectToPage("/Customer/CnicInfoResumeApplication");
        }
        public IActionResult OnPostBO()
        {
            return RedirectToPage("/BackOffice/LoginPage");
        }
    }
}
