using DigitalAccOpening.DB.ParameterizedDBTableClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DigitalAccOpening.Pages.Customer
{
    public class OccupationInfoPageModel : PageModel
    {
        private readonly DB.ApplicationDbContext _dbContext;
        public OccupationInfoPageModel(DB.ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [BindProperty]
        public string occupation { get; set; }=string.Empty;
        public List<DB.ParameterizedDBTableClasses.Occupation> occupations { get; set; }
        public async Task OnGetAsync()
        {
            occupations=await _dbContext.DefinedOccupation.ToListAsync();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            var customerID = HttpContext.Session.GetInt32("CustomerID");
            int OccupationID = await _dbContext.DefinedOccupation.Where(d => d.OccupationName == occupation).Select(d => d.OccupationID).FirstOrDefaultAsync();
            DB.DBTableClasses.CustomerOccupation customerOccupation = new DB.DBTableClasses.CustomerOccupation();
            customerOccupation.CustomerID = customerID.Value;
            customerOccupation.OccupationID = OccupationID;
            _dbContext.CustomerOccupation.Add(customerOccupation);
            await _dbContext.SaveChangesAsync();


            if (!string.IsNullOrEmpty(occupation))
            {
                if (occupation == "Student")
                {
                    return RedirectToPage("StudentSourceOfFundsPage");
                }
                else
                {
                    return RedirectToPage("TypeOfBankingInfo");
                }
            }
            return Page();

        }
    }
}
