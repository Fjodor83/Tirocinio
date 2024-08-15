using System.Net;
using System.Net.Mail;
using API.Interfaces;
using Microsoft.Extensions.Configuration;

namespace API.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendConfirmationEmailAsync(string email, string confirmationToken)
        {
            var subject = "Conferma il tuo indirizzo email";
            var body = $"Per favore, conferma il tuo indirizzo email cliccando su questo link: {_configuration["AppUrl"]}/api/auth/confirm-email?email={email}&token={confirmationToken}";

            await SendEmailAsync(email, subject, body);
        }

        public async Task SendPasswordResetEmailAsync(string email, string resetToken)
        {
            var subject = "Reimposta la tua password";
            var body = $"Per reimpostare la tua password, clicca su questo link: {_configuration["AppUrl"]}/reset-password?email={email}&token={resetToken}";

            await SendEmailAsync(email, subject, body);
        }

        private async Task SendEmailAsync(string email, string subject, string body)
        {
            var smtpClient = new SmtpClient(_configuration["Smtp:Host"])
            {
                Port = int.Parse(_configuration["Smtp:Port"]),
                Credentials = new NetworkCredential(_configuration["Smtp:Username"], _configuration["Smtp:Password"]),
                EnableSsl = bool.Parse(_configuration["Smtp:EnableSsl"])
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(_configuration["Smtp:FromEmail"]),
                Subject = subject,
                Body = body,
                IsBodyHtml = true,
            };
            mailMessage.To.Add(email);

            await smtpClient.SendMailAsync(mailMessage);
        }
    }
}