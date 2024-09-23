using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MimeKit;
using MailKit.Net.Smtp;
using Microsoft.EntityFrameworkCore;


namespace DigitalAccOpening.Pages.FurtherInfo
{
    public class LastPageModel : PageModel
    {
        private readonly DB.ApplicationDbContext _dbContext;
        public LastPageModel(DB.ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

        }
        public int customerID { get; private set; }

        public async void OnGet()
        {
            customerID = getCustomerID();
            string gmail = await _dbContext.Customer.Where(c => c.CustomerID == customerID).Select(c => c.Email).FirstOrDefaultAsync();
            sendEmail(gmail, customerID.ToString());
        }
        public int getCustomerID()
        {
            var CustomerID = HttpContext.Session.GetInt32("CustomerID");
           
            return CustomerID.Value;
            

        }

        public void sendEmail(string email, string trackingid)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("ABC Bank", "faisalishfaq59@gmail.com"));
            message.To.Add(new MailboxAddress("",email));
            message.Subject = "Tracking of Account Opening Applocation";

            message.Body = new TextPart("plain")
            {
                Text = $"Dear Customer, Your application for account opening in ABC Bank is submitted. For tracking the application plz use your tracking id: {trackingid} "
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

        public IActionResult OnPost()
        {
            return RedirectToPage("Index");
        }
        

    }
}
