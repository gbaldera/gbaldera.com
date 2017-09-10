using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace GBaldera.Web.Services 
{
    public class GmailSender : IEmailSender 
    {
        private readonly IConfiguration _configuration;

        public GmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Task SendEmail(string to, string subject, string message)
        {
            return Task.FromResult(0);
        }
    }
}