using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DigitalAccOpening.Pages.FurtherInfo
{
    public class PreferencesPage1Model : PageModel
    {

        private readonly DB.ApplicationDbContext _dbContext;
        public PreferencesPage1Model(DB.ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [BindProperty]
        public string preferedCity { get; set; }

        [BindProperty]
        public string preferedBranch { get; set; }

        [BindProperty]
        public string? referalCode { get; set; }
        public void OnGet()
        {
            ViewData["ActivePage"] = "Preferences";
        }
        public async Task<IActionResult> OnPostAsync()
        {
            var CustomerID = HttpContext.Session.GetInt32("CustomerID");
            DB.DBTableClasses.CustomerPreferences customerPreferences = new DB.DBTableClasses.CustomerPreferences();
            customerPreferences.CustomerPreferedCity=preferedCity;
            customerPreferences.CustomerPreferedBranch = preferedBranch;
            customerPreferences.CustomerReferalCode = referalCode;

            customerPreferences.CustomerID = CustomerID.Value;
            _dbContext.CustomerPreferences.Add(customerPreferences);
            await _dbContext.SaveChangesAsync();
            return RedirectToPage("ZakatExemptionPage");
        }
    }
}
