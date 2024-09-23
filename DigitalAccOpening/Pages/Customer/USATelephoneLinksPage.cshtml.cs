using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DigitalAccOpening.Pages.Customer
{
    public class USATelephoneLinksPageModel : PageModel
    {
        private readonly DB.ApplicationDbContext _dbContext;
        public USATelephoneLinksPageModel(DB.ApplicationDbContext dbContext)
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
            return RedirectToPage("USAMandatePage");
        }
        public async Task<IActionResult> OnPostNo()
        {
            bool val =false;
            await SaveInDatabase(val);
            return RedirectToPage("USAMandatePage");
        }

        public async Task SaveInDatabase(bool option)
        {
            var CustomerFurtherInfoID = HttpContext.Session.GetInt32("CustomerFurtherInfoID");
            var CustomerFurtherInfo = await _dbContext.CustomerFurtherInfo.FindAsync
                (CustomerFurtherInfoID.Value);
            CustomerFurtherInfo.IsUSALinks = option;

            await _dbContext.SaveChangesAsync();

        }
    }
}
