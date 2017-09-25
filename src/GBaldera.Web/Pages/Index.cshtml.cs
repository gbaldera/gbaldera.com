using System;
using System.Threading.Tasks;
using GBaldera.Web.Logging;
using GBaldera.Web.Models;
using GBaldera.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PaulMiami.AspNetCore.Mvc.Recaptcha;

namespace GBaldera.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IConfiguration _configuration;
        private readonly IEmailSender _emailSender;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(IEmailSender emailSender, IConfiguration configuration, ILoggerFactory loggerFactory)
        {
            _configuration = configuration;
            _emailSender = emailSender;
            _logger = loggerFactory.CreateLogger<IndexModel>();
        }

        [BindProperty]
        public Contact Contact { get; set; }

        public void OnGet()
        {
        }

        [ValidateRecaptcha]
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            try
            {
                var to = new MailAddress {Name = string.Empty, Email = _configuration["EmailSettings:ContactEmail"]};
                var from = new MailAddress {Name = Contact.Name, Email = Contact.Email};

                await _emailSender.SendEmail(from, to, _configuration["EmailSettings:Subject"], Contact.Message);
            }
            catch (Exception exception)
            {
                _logger.LogError(LoggingEvents.SendingEmail, exception,
                    "There is an error sending the contact information");
            }

            return RedirectToPage();
        }
    }
}