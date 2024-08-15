namespace API.Interfaces
{
    public interface IEmailService
    {
        Task SendConfirmationEmailAsync(string email, string confirmationToken);
        Task SendPasswordResetEmailAsync(string email, string resetToken);
    }
}