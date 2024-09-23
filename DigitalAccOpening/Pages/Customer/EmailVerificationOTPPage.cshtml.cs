using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MailKit.Net.Smtp;
using MimeKit;
using System.ComponentModel.DataAnnotations;

namespace DigitalAccOpening.Pages.Customer
{
    public class EmailVerificationOTPPageModel : PageModel
    {
        private readonly DB.ApplicationDbContext _dbContext;

        public EmailVerificationOTPPageModel(DB.ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [BindProperty(SupportsGet =true)]
        public string Gmail { get; set; }

        [BindProperty]
        public string OtpInput { get; set; }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if(Request.Form.ContainsKey("resendOtp"))
            {
                var otp = new Random().Next(000000, 999999).ToString("D6");

                HttpContext.Session.SetString("otp", otp);
                sendEmail(Gmail, otp);

            }
            var inputs = Request.Form["OtpInput"];
            OtpInput=string.Concat(inputs);

            var storedOtp = HttpContext.Session.GetString("otp");
            if (storedOtp == OtpInput)
            {
                var CustomerID = HttpContext.Session.GetInt32("CustomerID");
                try
                {
                    var Customer = await _dbContext.Customer.FindAsync(CustomerID.Value);
                    Customer.Email = Gmail;
                    Customer.IsApplicationCompleted = false;
                    await _dbContext.SaveChangesAsync();
                }
                catch
                {
                    return RedirectToPage("ServiceNotGivenPage");
                }
                
                return RedirectToPage("TaxResidentOfAnotherCountryPage");
            }
            else {
                ModelState.AddModelError(string.Empty, "Incorrect OTP. Please try again.");
                return Page();
            }
            
        }

        public void sendEmail(string email, string otp)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("ABC Bank", "faisalishfaq59@gmail.com"));
            message.To.Add(new MailboxAddress("", email));
            message.Subject = "OTP for Account Opening Request";

            message.Body = new TextPart("plain")
            {
                Text = $"Dear Customer, Your OTP for the account opening is: {otp} "
            };

            using (var client = new SmtpClient())
            {
                try
                {

                    client.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                    client.Authenticate("faisalishfaq59@gmail.com", "qnke zjyj iknp huio");
                    client.Send(message);
                }
                catch (Exception ex)
                {
                    ViewData["ErrorMessage"] = "error message" + ex.Message;
                }
                finally
                {
                    client.Disconnect(true);
                }
            }
        }
    }
}
