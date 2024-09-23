using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace DigitalAccOpening.Pages.Customer
{
    public class CnicInfoModel : PageModel
    {
        private readonly DB.ApplicationDbContext _dbContext;
        public CnicInfoModel(DB.ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }  

        [BindProperty]
        [Required(ErrorMessage = "Please select Cnic.")]
        public string Cnic {  get; set; }

        public string encryptedCnic;
        public void OnGet()
        {
        }
        public string message { get; set; } = string.Empty;

        public async Task<IActionResult> OnPostAsync()
        {
            

            if (ModelState.IsValid) {
               encryptedCnic = CommonFunctions.EncryptionHelper.Encrypt(Cnic);
            }
            if (await checkCnic(encryptedCnic))
            {
                message = "Your Application already exists, resume your application";
                return Page();

            }
            else
            {
                DB.DBTableClasses.Customer customer = new DB.DBTableClasses.Customer();
                customer.Cnic = encryptedCnic;

                _dbContext.Customer.Add(customer);
                await _dbContext.SaveChangesAsync();


                HttpContext.Session.SetInt32("CustomerID", customer.CustomerID);
                return RedirectToPage("PhoneNoInfo");
                
            }
        }
        public async Task<bool> checkCnic(string cnic)
        {
            return await _dbContext.Customer.AnyAsync(c => c.Cnic == cnic);
        }
    }
}
