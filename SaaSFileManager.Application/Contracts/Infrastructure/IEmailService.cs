namespace SaaSFileManager.Application.Contracts.Infrastructure
{
    public interface IEmailService
    {
        Task SendActivationEmailAsync(string toEmail, string activationLink);
    }
}
