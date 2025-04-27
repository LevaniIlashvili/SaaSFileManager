using SaaSFileManager.Domain.Entities;

namespace SaaSFileManager.Application.Contracts.Persistence
{
    public interface ICompanyRepository : IAsyncRepository<Company>
    {
        Task<bool> IsCompanyEmailUnique(string email);
        Task<Company?> GetByActivationToken(string token);
        Task<Company?> GetByEmailAsync(string email);
    }
}
