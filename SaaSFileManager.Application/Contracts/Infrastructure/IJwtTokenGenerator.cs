namespace SaaSFileManager.Application.Contracts.Infrastructure
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(Guid id, string email);
    }
}
