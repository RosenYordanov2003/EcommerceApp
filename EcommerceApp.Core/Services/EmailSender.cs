namespace EcommerceApp.Core.Services
{
    using Microsoft.AspNetCore.Identity.UI.Services;
    using System.Net;
    using System.Net.Mail;

    public class EmailSender: IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            string appEmail = "fashionstore998474@gmail.com";
            string appEmailPassword = "joyw xmyg bwuf fopm";

            MailMessage message = new MailMessage();
            message.From = new MailAddress(appEmail);
            message.Subject = subject;
            message.To.Add(new MailAddress(email));
            message.Body = htmlMessage;
            message.IsBodyHtml = true;

            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(appEmail, appEmailPassword),
                EnableSsl = true,
            };

            try
            {
                smtpClient.Send(message);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                smtpClient.Dispose();
            }
        }
    }
}
