using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DigitalAccOpening.Pages.Customer
{
    public class POAModel : PageModel
    {
        private readonly DB.ApplicationDbContext _dbContext;
        public POAModel(DB.ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }



        [BindProperty]
        public string purpose { get; set; }=string.Empty;

        public List<DB.ParameterizedDBTableClasses.Purpose> purposes { get; set; }
        public async Task OnGetAsync()
        {
            purposes = await _dbContext.DefinedPurpose.ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                var customerID = HttpContext.Session.GetInt32("CustomerID");
                int PurposeID = await _dbContext.DefinedPurpose.Where(dp => dp.PurposeName == purpose).Select(dp => dp.PurposeID).FirstOrDefaultAsync();
                DB.DBTableClasses.CustomerPurpose customerPurpose = new DB.DBTableClasses.CustomerPurpose();
                customerPurpose.CustomerID = customerID.Value;
                customerPurpose.PurposeID = PurposeID;
                _dbContext.CustomerPurpose.Add(customerPurpose);
                await _dbContext.SaveChangesAsync();

            }
            catch(Exception e)
            {
                

            }


            if(!(string.IsNullOrEmpty(purpose)))
            {
                if(purpose =="Salary")
                {
                    return RedirectToPage("PurposeOfAccount-SalaryDetailsPage");
                }
                else if (purpose =="Pension")
                {
                    return RedirectToPage("PurposeOfAccount-PensionDetailsPage");
                }
                else if(purpose == "HomeRemittance")
                {
                    return RedirectToPage("PurposeOfAccount-HomeRemittanceDetailsPage");
                }
                else
                {
                    return RedirectToPage("OccupationInfoPage");
                }
            }
            return Page();
            
        }
    }
}
