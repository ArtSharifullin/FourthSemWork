using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MimeKit;
using Spovest.Application.Interfaces.Services;
using Spovest.Infrastructure.Settings;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;


namespace Spovest.Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _emailSettings;

        public EmailService(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public async Task<bool> SendEmailAsync(string fullname, string toEmail, string subject, string htmlMessage)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(_emailSettings.Name, _emailSettings.Email));
            message.To.Add(new MailboxAddress(toEmail, toEmail));
            message.Subject = subject;
            message.Body = new TextPart("html")
            {
                Text = $"<h3>Сообщение от пользователя по имени: {fullname}</h3>\n" + htmlMessage
            };

            try
            {
                await SendMessage(message);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при отправке письма: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> SendMessage(MimeMessage message)
        {
            using (var client = new SmtpClient())
            {
                client.CheckCertificateRevocation = _emailSettings.CheckCertificateRevocation;
                await client.ConnectAsync(_emailSettings.Host, _emailSettings.Port, true);
                await client.AuthenticateAsync(_emailSettings.Email, _emailSettings.Password);
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
                return true;
            }

        }
    }
}
