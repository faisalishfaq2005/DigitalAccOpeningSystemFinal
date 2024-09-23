using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DigitalAccOpening.Pages.Customer
{
    public class PurposeOfAccount_PensionDetailsPageModel : PageModel
    {
        private readonly DB.ApplicationDbContext _dbContext;
        public PurposeOfAccount_PensionDetailsPageModel(DB.ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [BindProperty]
        public string governmentorprivatepensioner { get; set; }=string.Empty;

        public List<DB.ParameterizedDBTableClasses.PensionerType> pensionerTypes { get; set; }
        public async Task OnGetAsync()
        {
            pensionerTypes=await _dbContext.DefinedPensionerType.ToListAsync(); 
        }
        public IActionResult OnPost()
        {
            return RedirectToPage("TypeOfBankingInfo");
        }
    }
}
