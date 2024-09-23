using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DigitalAccOpening.Pages.Customer
{
    public class USAMandatePageModel : PageModel
    {
        private readonly DB.ApplicationDbContext _dbContext;
        public USAMandatePageModel(DB.ApplicationDbContext dbContext)
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
            return RedirectToPage("POA");
        }
        public async Task<IActionResult> OnPostNoAsync()
        {
            bool val = false;
            await SaveInDatabase(val);
            return RedirectToPage("POA");
        }

        public async Task SaveInDatabase(bool option)
        {
            var CustomerFurtherInfoID = HttpContext.Session.GetInt32("CustomerFurtherInfoID");
            var CustomerFurtherInfo = await _dbContext.CustomerFurtherInfo.FindAsync
                (CustomerFurtherInfoID.Value);
            CustomerFurtherInfo.IsUSAMandate = option;

            await _dbContext.SaveChangesAsync();

        }
    }
}
