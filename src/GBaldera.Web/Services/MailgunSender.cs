using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using GBaldera.Web.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace GBaldera.Web.Services
{
    public class MailgunSender : IEmailSender
    {
        private readonly MailgunClient _client;
        private readonly IConfiguration _configuration;

        public MailgunSender(IConfiguration configuration)
        {
            _configuration = configuration;
            _client = new MailgunClient(configuration["Mailgun:ApiKey"], configuration["Mailgun:Domain"]);
        }

        public async Task SendEmail(MailAddress from, MailAddress to, string subject, string message)
        {
            await _client.SendEmail(new MailgunRequest
            {
                From = from,
                To = new List<MailAddress> {to},
                Subject = subject,
                Body = message,
                IsHtml = true
            });
        }
    }

    public class MailgunClient
    {
        private const string ApiUrl = "https://api.mailgun.net/v3/";
        private readonly string _domain;
        private readonly HttpClient _http;

        public MailgunClient(string apiKey, string domain)
        {
            if (string.IsNullOrEmpty(apiKey))
                throw new ArgumentNullException(nameof(apiKey));
            if (string.IsNullOrEmpty(domain))
                throw new ArgumentNullException(nameof(domain));

            _domain = domain;
            _http = new HttpClient();
            _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                Convert.ToBase64String(Encoding.UTF8.GetBytes($"api:{apiKey}")));
        }

        public async Task<MailgunResponse> SendEmail(MailgunRequest request)
        {
            var fullUri = new Uri(new Uri(ApiUrl), $"{_domain}/messages");

            using (var requestMessage = new HttpRequestMessage(HttpMethod.Post, fullUri))
            {
                var parameters = new Dictionary<string, string>
                {
                    {"from", $"{request.From.Name} <{request.From.Email}>"},
                    {"subject", request.Subject},
                    {request.IsHtml ? "html" : "text", request.Body}
                };

                var toSb = new StringBuilder();

                foreach (var to in request.To)
                    toSb.Append($"{to.Name} <{to.Email}>,");

                parameters.Add("to", toSb.ToString());
                requestMessage.Content = new FormUrlEncodedContent(parameters);

                var response = await _http.SendAsync(requestMessage);

                response.EnsureSuccessStatusCode();
                var responseText = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<MailgunResponse>(responseText);
            }
        }
    }

    public class MailgunRequest
    {
        public MailAddress From { get; set; }
        public ICollection<MailAddress> To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool IsHtml { get; set; }
    }

    public class MailgunResponse
    {
        public string Id { get; set; }
        public string Message { get; set; }
    }
}