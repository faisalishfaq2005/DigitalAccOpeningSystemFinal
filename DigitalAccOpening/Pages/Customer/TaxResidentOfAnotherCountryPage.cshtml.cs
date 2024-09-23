using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DigitalAccOpening.Pages.Customer
{
    public class TaxResidentOfAnotherCountryPageModel : PageModel
    {
        private readonly DB.ApplicationDbContext _dbContext;
        public TaxResidentOfAnotherCountryPageModel(DB.ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostYesAsync()
        {
            
            bool val = true;
            await SaveInDatabase(val);
            return RedirectToPage("OtherNationalityPage");
        }
        public async Task<IActionResult> OnPostNoAsync()
        {
            
            bool val = false;
            await SaveInDatabase(val);
            return RedirectToPage("OtherNationalityPage");
        }

        public async Task SaveInDatabase(bool option)
        {
            var CustomerID = HttpContext.Session.GetInt32("CustomerID");
            DB.DBTableClasses.CustomerFurtherInfo customerFurtherInfo=new DB.DBTableClasses.CustomerFurtherInfo();
            customerFurtherInfo.TaxResidentAnotherCountry= option;
            customerFurtherInfo.CustomerID= CustomerID;
            
            _dbContext.CustomerFurtherInfo.Add(customerFurtherInfo);
            await _dbContext.SaveChangesAsync();
            HttpContext.Session.SetInt32("CustomerFurtherInfoID", customerFurtherInfo.CustomerFurtherInfoID);
        }
    }
}
