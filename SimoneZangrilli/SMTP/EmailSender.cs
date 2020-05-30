using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace SimoneZangrilli.SMTP
{
    public class EmailSender : IEmailSender
    {
        private readonly SmtpSettings _smtpSettings;
        public EmailSender(IOptions<SmtpSettings> smtpSettings)
        {
            _smtpSettings = smtpSettings.Value;

        }

        public async Task<Task> SendEmailAsync(string email, string subject, string message)
        {
            var from = _smtpSettings.FromAddress;
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("dilillo.nico@gmail.com");
                mail.To.Add("nicola.dilillo@icloud.com");
                mail.Subject = "Hello World";
                mail.Body = "<h1>Hello</h1>";
                mail.IsBodyHtml = true;        

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential("dilillo.nico@gmail.com", "Vivi2706?");
                    //smtp.UseDefaultCredentials = false;
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }

            return Task.CompletedTask;
        }
    }
}
