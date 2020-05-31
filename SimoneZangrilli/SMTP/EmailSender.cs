using System.Web;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting.Internal;
using System.Reflection;

namespace SimoneZangrilli.SMTP
{
    public class EmailSender : IEmailSender
    {
        private readonly SmtpSettings _smtpSettings;
        public EmailSender(IOptions<SmtpSettings> smtpSettings)
        {
            _smtpSettings = smtpSettings.Value;

        }

        public async Task<Task> SendEmailAsync(string email, string message, string firstname, string lastname)
        {
            string html = File.ReadAllText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Templates\Success.html"));
            var body = html
                     .Replace("{{Name}}", firstname)
                     .Replace("{{LastName}}", lastname)
                     .Replace("{{Email}}", email)
                     .Replace("{{Message}}", message);

            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(_smtpSettings.FromAddress);
                mail.To.Add(_smtpSettings.ToAddress);
                mail.Subject = "Nuovo Contatto";
                mail.Body = body;
                mail.IsBodyHtml = true;        

                using (SmtpClient smtp = new SmtpClient(_smtpSettings.Server, _smtpSettings.Port))
                {
                    smtp.Credentials = new NetworkCredential(_smtpSettings.FromAddress, _smtpSettings.Password);
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(mail);
                }
            }

            return Task.CompletedTask;
        }
    }
}
