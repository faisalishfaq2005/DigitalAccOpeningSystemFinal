using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MailKit.Net.Smtp;
using MimeKit;
using System.ComponentModel.DataAnnotations;

namespace DigitalAccOpening.Pages.Customer
{
    public class gmailModel : PageModel
    {

        [BindProperty,Required]
        public string Gmail { get; set; }
       
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if(!string.IsNullOrEmpty(Gmail))
            {
                var otp = new Random().Next(000000, 999999).ToString("D6");

                HttpContext.Session.SetString("otp", otp);
                sendEmail(Gmail,otp);

                return RedirectToPage("EmailVerificationOTPPage",new {gmail=Gmail });

            }
            return Page();
            
        }

        public void sendEmail(string email,string otp)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("ABC Bank", "faisalishfaq59@gmail.com"));
            message.To.Add(new MailboxAddress("",email));
            message.Subject = "OTP for Account Opening Request";

            message.Body = new TextPart("plain")
            {
                Text = $"Dear Customer, Your OTP for the account opening is: {otp} "
            };

            using(var client=new SmtpClient())
            {
                try
                {

                    client.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                    client.Authenticate("faisalishfaq59@gmail.com", "qnke zjyj iknp huio");
                    client.Send(message);
                }
                catch (Exception ex)
                {
                    ViewData["ErrorMessage"]="error message"+ex.Message;
                }
                finally
                {
                    client.Disconnect(true);
                }
            }
        }
    }
}
