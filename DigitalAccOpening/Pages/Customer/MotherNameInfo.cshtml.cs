using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace DigitalAccOpening.Pages.Customer
{
    public class MotherNameInfoModel : PageModel
    {
        private readonly DB.ApplicationDbContext _dbContext;

        public MotherNameInfoModel(DB.ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [BindProperty]
        [Required]
        public string MotherName { get; set; }=String.Empty;
        

        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            var CustomerFurtherInfoID = HttpContext.Session.GetInt32("CustomerFurtherInfoID");
            var CustomerFurtherInfo = await _dbContext.CustomerFurtherInfo.FindAsync(CustomerFurtherInfoID);
            if (CustomerFurtherInfo != null)
            {
                CustomerFurtherInfo.MotherName = MotherName;
                await _dbContext.SaveChangesAsync();
            }
            
            return RedirectToPage("PlaceOfBirthPage");

        }
    }
}
