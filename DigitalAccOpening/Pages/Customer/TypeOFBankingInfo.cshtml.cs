using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DigitalAccOpening.Pages.Customer
{
    public class TypeOFBankingInfoModel : PageModel
    {
        private readonly DB.ApplicationDbContext _dbContext;

        public TypeOFBankingInfoModel(DB.ApplicationDbContext dbContext)
            {
            _dbContext = dbContext;
            }
        [BindProperty]
        public string bankingtype { get; set; }=string.Empty;

        public List<DB.ParameterizedDBTableClasses.BankingType> bankingTypes { get; set; }
        public async Task OnGetAsync()
        {
            bankingTypes = await _dbContext.DefinedBankingType.ToListAsync();
        }
        public async  Task<IActionResult> OnPostAsync() 
        {
            try
            {
                var CustomerFurtherInfoID = HttpContext.Session.GetInt32("CustomerFurtherInfoID");
                var CustomerFurtherInfo =await _dbContext.CustomerFurtherInfo.FindAsync(CustomerFurtherInfoID);
                int bankingtypeid = await _dbContext.DefinedBankingType.Where(bt => bt.BankingTypeName == bankingtype).Select(bt => bt.BankingTypeID).FirstOrDefaultAsync();
                CustomerFurtherInfo.BankingTypeID = bankingtypeid;
                await _dbContext.SaveChangesAsync();
            }
            catch { }

            if (!string.IsNullOrEmpty(bankingtype))
            {
                return RedirectToPage("TypeOfAccountInfoPage", new { bankingType = bankingtype });
            }
            return Page();

        }
    }
}
