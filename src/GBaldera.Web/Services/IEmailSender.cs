using System.Threading.Tasks;
using GBaldera.Web.Models;

namespace GBaldera.Web.Services
{
    public interface IEmailSender
    {
        Task SendEmail(MailAddress from, MailAddress to, string subject, string message);
    }
}