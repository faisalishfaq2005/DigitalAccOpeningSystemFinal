using DigitalAccOpening.DB.DBTableClasses;
using DigitalAccOpening.Pages.FurtherInfo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DigitalAccOpening.Pages.BackOffice
{
    public class ViewCustomersListModel : PageModel
    {
        private readonly DB.ApplicationDbContext _dbContext;
        public ViewCustomersListModel(DB.ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [BindProperty]
        public int selectedCustomerID { get; set; }

        public List<int> CustomerIDs { get; set; }
        public async Task OnGetAsync()
        {
            CustomerIDs = await _dbContext.Customer.Where(c => c.IsApplicationCompleted==true && c.IsForwarded==false)
           .Select(c => c.CustomerID) // Select only the CustomerID column
           .ToListAsync();
        }

        public IActionResult OnPost()
        {
            HttpContext.Session.SetInt32("SelectedCustomerID", selectedCustomerID);
            return RedirectToPage("ViewCustomerData");
        }
    }
}
