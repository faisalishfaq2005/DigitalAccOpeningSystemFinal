using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DigitalAccOpening.Pages.Customer
{
    public class PurposeOfAccount_SalaryDetailsPageModel : PageModel
    {
        private readonly DB.ApplicationDbContext _dbContext;

        public PurposeOfAccount_SalaryDetailsPageModel(DB.ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        [BindProperty]
        [Required]
        public string natureofemployement { get; set; } = string.Empty;

        public List<DB.ParameterizedDBTableClasses.NatureOfEmployement> NatureOfEmployement; 
        public async void OnGetAsync()
        {
            NatureOfEmployement = await _dbContext.DefinedNatureOFEmployement.ToListAsync();
        }

        public async Task <IActionResult> OnPostAsync()
        {

            try
            {
                var CustomerID = HttpContext.Session.GetInt32("CustomerID");
                int NatureOfEmployementID =await _dbContext.DefinedNatureOFEmployement.Where(nt => nt.NatureOfEmployementName == natureofemployement).Select(nt => nt.NatureOfEmployementID).FirstOrDefaultAsync();
                DB.DBTableClasses.CustomerNatureOfEmployement customerNatureOfEmployement = new DB.DBTableClasses.CustomerNatureOfEmployement();
                customerNatureOfEmployement.CustomerID = CustomerID.Value;
                customerNatureOfEmployement.NatureOfEmployementID = NatureOfEmployementID;
                _dbContext.CustomerNatureOfEmployement.Add(customerNatureOfEmployement);
                await _dbContext.SaveChangesAsync();
            }
            catch { }


            if(!(string.IsNullOrEmpty(natureofemployement)))
            {
                if (natureofemployement == "GovernmentEmployee")
                {
                    return RedirectToPage("EmployementSectorPage");
                }
                else if (natureofemployement == "PrivateCompanyEmployee")
                {
                    return RedirectToPage("EmployementDetails");
                }


            }
            return Page();
        }

    }
}
