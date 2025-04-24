using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using SaaSFileManager.Application.Contracts.Infrastructure;
using SaaSFileManager.Application.Models.Mail;

namespace SaaSFileManager.Infrastructure.Mail
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _emailSettings;

        public EmailService(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string message)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_emailSettings.FromEmail));
            email.To.Add(MailboxAddress.Parse(toEmail));
            email.Subject = subject;

            email.Body = new TextPart("html")
            {
                Text = message
            };

            using var smtp = new SmtpClient();
            await smtp.ConnectAsync(
                _emailSettings.SmtpHost,
                int.Parse(_emailSettings.SmtpPort.ToString()),
                SecureSocketOptions.StartTls);

            await smtp.AuthenticateAsync(
                _emailSettings.Username,
                _emailSettings.Password);

            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);
        }

        public async Task SendActivationEmailAsync(string toEmail, string activationLink)
        {
            var subject = "Activate Your Account";
            var html = $@"
                <h2>Welcome to Our Platform!</h2>
                <p>Please activate your account by clicking the link below:</p>
                <a href='{activationLink}'>Activate Account</a>";

            await SendEmailAsync(toEmail, subject, html);
        }
    }
}
