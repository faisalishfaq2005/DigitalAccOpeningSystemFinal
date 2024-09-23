using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DigitalAccOpening.Pages.Customer
{
    public class OtherNationalityPageModel : PageModel
    {
        private readonly DB.ApplicationDbContext _dbContext;
        public OtherNationalityPageModel(DB.ApplicationDbContext dbContext)
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
            return RedirectToPage("SelectNationalityPage");
        }
        public async Task<IActionResult> OnPostNoAsync()
        {
            bool val = false;
            await SaveInDatabase(val);

            return RedirectToPage("MotherNameInfo");

        }
        public async Task SaveInDatabase(bool option)
        {
            var CustomerFurtherInfoID = HttpContext.Session.GetInt32("CustomerFurtherInfoID");
            var CustomerFurtherInfo= await _dbContext.CustomerFurtherInfo.FindAsync
                (CustomerFurtherInfoID.Value);
            CustomerFurtherInfo.OtherNationalities = option;
           
            await _dbContext.SaveChangesAsync();

        }
    }
}
