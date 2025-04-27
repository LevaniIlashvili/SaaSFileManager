namespace SaaSFileManager.Application.Contracts.Security
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(Guid id, string email);
    }
}
