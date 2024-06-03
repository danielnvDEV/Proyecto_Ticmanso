using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TicmansoV2.Shared.Contracts;
using TicmansoV2.Shared;
using Humanizer;
using MailKit.Security;
using MimeKit;
using Microsoft.Extensions.Options;
using MimeKit.Text;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Cors;

namespace TicmansoWebApiV2.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly EmailSettings _emailSettings;

        public EmailController(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        [HttpPost]
        public async Task<IActionResult> SendEmail(EmailDTO emailDTO)
        {
            var message = new MimeMessage();
            message.From.Add(MailboxAddress.Parse(_emailSettings.Username));
            message.To.Add(MailboxAddress.Parse(emailDTO.ToEmail));
            message.Subject = emailDTO.Subject;
            message.Body = new TextPart(TextFormat.Html) { Text = emailDTO.Body };

            using var client = new SmtpClient();
            
            await client.ConnectAsync(_emailSettings.Host, _emailSettings.Port, SecureSocketOptions.StartTls);
            await client.AuthenticateAsync(_emailSettings.Username, _emailSettings.Password);
            await client.SendAsync(message);
            await client.DisconnectAsync(true);
            

            return Ok();
        }
    }
}
