namespace SaaSFileManager.Application.Contracts.Infrastructure
{
    public interface ILoggedInUserService
    {
        string UserId { get; }
        string Role { get; }
    }
}
