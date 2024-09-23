using MailKit.Net.Smtp;
using MimeKit;

namespace DigitalAccOpening.CommonFunctions
{
    public class SendEmailFunction
    {
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
                   
                }
                finally
                {
                    client.Disconnect(true);
                }
            }
        }
    }
}
