using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MailAddress = GBaldera.Web.Models.MailAddress;

namespace GBaldera.Web.Services
{
    public class GmailSender : IEmailSender
    {
        private readonly IConfiguration _configuration;

        public GmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmail(MailAddress from, MailAddress to, string subject, string message)
        {
            var mailMessage = new MailMessage
            {
                From = from,
                Subject = subject,
                Body = message,
                IsBodyHtml = true
            };

            mailMessage.To.Add(to);

            if (int.TryParse(_configuration["Smtp:ServerPort"], out var port))
                using (var smtp = new SmtpClient(_configuration["Smtp:ServerAddress"], port))
                {
                    smtp.Credentials =
                        new NetworkCredential(_configuration["Smtp:Username"], _configuration["Smtp:Password"]);
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(mailMessage);
                }
        }
    }
}