using Microsoft.Extensions.Options;
using System.Net.Mail;
using System.Net;
using TicmansoV2.Shared.Contracts;
using TicmansoV2.Shared;
using System.Net.Http;


namespace TicmansoV2.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailSettings _emailSettings;

        public EmailSender(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public async Task SendEmailAsync(string to, string subject, string body)
        {
            //var response = await httpClient.PutAsJsonAsync
        }
    }
}
