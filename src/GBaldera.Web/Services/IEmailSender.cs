using System.Threading.Tasks;

namespace GBaldera.Web.Services
{
    public interface IEmailSender
    {
        Task SendEmail(string to, string subject, string message);
    }
}