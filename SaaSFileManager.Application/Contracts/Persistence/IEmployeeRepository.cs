using SaaSFileManager.Domain.Entities;

namespace SaaSFileManager.Application.Contracts.Persistence
{
    public interface IEmployeeRepository : IAsyncRepository<Employee>
    {
        Task<bool> IsEmployeeEmailUnique(string email);
        Task<Employee?> GetByActivationToken(Guid activationToken);
    } 
}
