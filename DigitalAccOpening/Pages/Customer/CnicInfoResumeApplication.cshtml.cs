using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DigitalAccOpening.Pages.Customer
{
    public class CnicInfoResumeApplicationModel : PageModel
    {
        private readonly DB.ApplicationDbContext _dbContext;
        public CnicInfoResumeApplicationModel(DB.ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [BindProperty]
        [Required(ErrorMessage = "Please select Cnic.")]
        public string Cnic { get; set; }

        public string encryptedCnic;
        public void OnGet()
        {
        }

        public string message { get; set; } = string.Empty;

        public async Task<IActionResult> OnPostAsync()
        {


            if (ModelState.IsValid)
            {
                encryptedCnic = CommonFunctions.EncryptionHelper.Encrypt(Cnic);
            }
            if (await checkCnic(encryptedCnic)>0)
            {
                int CusID =await checkCnic(encryptedCnic);
                var customerPersonalInfo = await _dbContext.CustomerPersonalInfo.Where(p => p.CustomerID == CusID).FirstOrDefaultAsync();
                if(customerPersonalInfo.CustomerFatherName!=null && customerPersonalInfo.CustomerFatherName!=null)
                {
                    var customerNextKinInfo = await _dbContext.CustomerNextOfKinInfo.Where(p => p.CustomerID == CusID).FirstOrDefaultAsync();
                    if( customerNextKinInfo==null || customerNextKinInfo.CustomerKinName==null)
                    {
                        return RedirectToPage("/FurtherInfo/NextOfKinInfoPage");
                    }
                    var customerpreferences= await _dbContext.CustomerPreferences.Where(p => p.CustomerID == CusID).FirstOrDefaultAsync();
                    if(customerpreferences==null || customerpreferences.CustomerPreferedCity==null)
                    {
                        return RedirectToPage("/FurtherInfo/PreferencesPage1");
                    }
                    var customerzakat = await _dbContext.CustomerZakatExemption.Where(p => p.CustomerID == CusID).FirstOrDefaultAsync();
                    if(customerzakat==null || customerzakat.CustomerMonthlyDebitTurnOver==null)
                    {
                        return RedirectToPage("/FurtherInfo/ZakatExemptionPage");
                    }
                    var customermailing = await _dbContext.CustomerMailingAddress.Where(p => p.CustomerID == CusID).FirstOrDefaultAsync();
                    if(customermailing==null || customermailing.CustomerPresentCountry==null)
                    {
                        return RedirectToPage("/FurtherInfo/MailingAddress");
                    }
                    var customerdocuments = await _dbContext.CustomerUploadDocuments.Where(p => p.CustomerID == CusID).FirstOrDefaultAsync();
                    if(customerdocuments==null || customerdocuments.CustomerCNICFront==null)
                    {
                        return RedirectToPage("/FurtherInfo/DocumentsUpload1");

                    }
                    var customerimage = await _dbContext.CustomerImage.Where(p => p.CustomerID == CusID).FirstOrDefaultAsync();
                    if(customerimage==null || customerimage.CustomerImageData==null)
                    {
                        return RedirectToPage("/FurtherInfo/CaptureImagePage");
                    }

                }

                return Page();


            }
            else
            {
                message = "Your Application does not exists, start your application";
                return Page();

            }

        }
        public async Task<int> checkCnic(string cnic)
        {
            int CusID = await _dbContext.Customer.Where(c => c.Cnic == cnic).Select(c => c.CustomerID).FirstOrDefaultAsync();
            return CusID;
        }
    }
}
