using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DigitalAccOpening.Pages.Customer
{
    public class TypeOfAccountInfoPageModel : PageModel
    {
        private readonly DB.ApplicationDbContext _dbContext;

        public TypeOfAccountInfoPageModel(DB.ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [BindProperty(SupportsGet=true)]
        public string bankingtype { get; set; }

        [BindProperty]
        public string accountType { get; set; }=string.Empty;

        public List<DB.ParameterizedDBTableClasses.AccountType> accountTypes { get; set; }
        public async Task OnGetAsync()
        {
            int? bankingtypeid= await _dbContext.DefinedBankingType.Where(bt => bt.BankingTypeName == bankingtype).Select(bt => bt.BankingTypeID).FirstOrDefaultAsync();

            if (bankingtypeid != null)
            {
                accountTypes = await _dbContext.DefinedAccountType.Where(at => at.BankingTypeID == bankingtypeid.Value).ToListAsync();
            }

        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                var CustomerFurtherInfoID = HttpContext.Session.GetInt32("CustomerFurtherInfoID");
                var CustomerFurtherInfo = await _dbContext.CustomerFurtherInfo.FindAsync(CustomerFurtherInfoID);
                int accounttypeid = await _dbContext.DefinedAccountType.Where(at => at.AccountTypeName ==accountType).Select(at =>at.AccountTypeID).FirstOrDefaultAsync();
                CustomerFurtherInfo.AccountTypeID = accounttypeid;
                await _dbContext.SaveChangesAsync();
            }
            catch { }
            if (!(string.IsNullOrWhiteSpace(accountType)))
            {
                return RedirectToPage("SourceOfFundsPage");
            }
            return Page();
        }

    }
}
