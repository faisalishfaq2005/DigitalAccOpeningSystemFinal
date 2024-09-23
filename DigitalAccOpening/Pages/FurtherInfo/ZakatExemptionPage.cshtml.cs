using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DigitalAccOpening.Pages.FurtherInfo
{
    public class ZakatExemptionPageModel : PageModel
    {
        private readonly DB.ApplicationDbContext _dbContext;
        public ZakatExemptionPageModel(DB.ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [BindProperty]
        public string MonthlyDebitTurnover { get; set; }

        [BindProperty]
        public string MonthlyCreditTurnover { get; set; }

        [BindProperty]
        public string ExpectedModeOfTransaction { get; set; }

        [BindProperty]
        public string MonthlyIncome { get; set; }

        public void OnGet()
        {
            ViewData["ActivePage"] = "ZakatExemption";
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var CustomerID = HttpContext.Session.GetInt32("CustomerID");
            DB.DBTableClasses.CustomerZakatExemption customerZakatExemption = new DB.DBTableClasses.CustomerZakatExemption();
            customerZakatExemption.CustomerMonthlyDebitTurnOver = MonthlyDebitTurnover;
            customerZakatExemption.CustomerMonthlyCreditTurnOver = MonthlyCreditTurnover;
            customerZakatExemption.CustomerExpectedModeOfTransaction = ExpectedModeOfTransaction;
            customerZakatExemption.CustomerMonthlyIncome = MonthlyIncome;
            customerZakatExemption.CustomerID = CustomerID.Value;

            _dbContext.CustomerZakatExemption.Add(customerZakatExemption);
            await _dbContext.SaveChangesAsync();

            return RedirectToPage("MailingAddress");
        }
    }
    
}
