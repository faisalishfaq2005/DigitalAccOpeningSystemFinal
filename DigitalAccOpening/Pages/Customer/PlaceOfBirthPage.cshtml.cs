using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.X509;

namespace DigitalAccOpening.Pages.Customer
{
    public class PlaceOfBirthPageModel : PageModel
    {
        private readonly DB.ApplicationDbContext _dbContext;

        public PlaceOfBirthPageModel(DB.ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [BindProperty]
        public string country { get; set; } = string.Empty;

        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            var CustomerFurtherInfoID = HttpContext.Session.GetInt32("CustomerFurtherInfoID");
            var CustomerFurtherInfo = await _dbContext.CustomerFurtherInfo.FindAsync(CustomerFurtherInfoID);
            if (CustomerFurtherInfo != null)
            {
                CustomerFurtherInfo.PlaceOfBirth= country;
                await _dbContext.SaveChangesAsync();
            }

            return RedirectToPage("USAResidentInfoPage");
        }
    }
}
