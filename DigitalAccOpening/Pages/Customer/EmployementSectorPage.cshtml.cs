using DigitalAccOpening.DB.ParameterizedDBTableClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DigitalAccOpening.Pages.Customer
{
    public class EmployementSectorPageModel : PageModel
    {
        private readonly DB.ApplicationDbContext _dbContext;
        public EmployementSectorPageModel(DB.ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [BindProperty]
        public string employementsector { get; set; } = string.Empty;
        public List<DB.ParameterizedDBTableClasses.EmployementSector> EmployementSectors { get; set; }  
        
        public async Task OnGetAsync()
        {
            EmployementSectors = await _dbContext.DefinedEmployementSector.ToListAsync();
        }

        public  async Task<IActionResult> OnPostAsync()
        {
            try
            {
                var customerID = HttpContext.Session.GetInt32("CustomerID");
                int EmployementSectorID = await _dbContext.DefinedEmployementSector.Where(es => es.EmployementSectorName == employementsector).Select(es => es.EmployementSectorID).FirstOrDefaultAsync();
                DB.DBTableClasses.CustomerEmployementSector customerEmployementSector =new DB.DBTableClasses.CustomerEmployementSector();
                customerEmployementSector.CustomerID = customerID.Value;
                customerEmployementSector.EmployementSectorID =EmployementSectorID ;
                _dbContext.CustomerEmployementSector.Add(customerEmployementSector);
                await _dbContext.SaveChangesAsync();

            }
            catch (Exception e)
            {


            }
            if (!(string.IsNullOrWhiteSpace(employementsector)))
            {
                return RedirectToPage("EmployementDetails");
            }
            return Page();
        }
    }

}
