using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DigitalAccOpening.Pages.FurtherInfo
{
    public class MailingAddressModel : PageModel
    {
        private readonly DB.ApplicationDbContext _dbContext;
        public MailingAddressModel(DB.ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [BindProperty]
        public string PresentCountry { get; set; }
        [BindProperty]
        public string PresentAddress{ get; set; }
        public void OnGet()
        {
            ViewData["ActivePage"] = "MailingAddress";
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var CustomerID = HttpContext.Session.GetInt32("CustomerID");
            DB.DBTableClasses.CustomerMailingAddress customerMailingAddress = new DB.DBTableClasses.CustomerMailingAddress();
            customerMailingAddress.CustomerPresentCountry = PresentCountry;
            customerMailingAddress.CustomerPresentAddress = PresentAddress;
            customerMailingAddress.CustomerID = CustomerID.Value;
            _dbContext.CustomerMailingAddress.Add(customerMailingAddress);
            await _dbContext.SaveChangesAsync();
            return RedirectToPage("DocumentsUpload1");
        }
    }
}
