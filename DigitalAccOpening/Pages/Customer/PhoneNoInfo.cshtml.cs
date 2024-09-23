using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;

namespace DigitalAccOpening.Pages.Customer
{
    public class PhoneNoInfoModel : PageModel
    {
        private readonly DB.ApplicationDbContext _dbContext;
        public PhoneNoInfoModel(DB.ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            
        }



        [BindProperty]
        public string PhoneNumber { get; set; }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            var CustomerID = HttpContext.Session.GetInt32("CustomerID");

           

            try
            {
                var customer = await _dbContext.Customer.FindAsync(CustomerID.Value);
                customer.PhoneNumber = PhoneNumber;
                await _dbContext.SaveChangesAsync();

                
            }
            catch (SqlNullValueException ex)
            {
                Console.WriteLine($"SqlNullValueException caught: {ex.Message}");
                // Log or handle the exception as needed
                return RedirectToPage("ServiceNotGivenPage");
            }

           
            return RedirectToPage("ValidEmailAddPage");
        }
    }
}
