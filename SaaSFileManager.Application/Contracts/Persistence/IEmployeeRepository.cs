using SaaSFileManager.Domain.Entities;

namespace SaaSFileManager.Application.Contracts.Persistence
{
    public interface IEmployeeRepository : IAsyncRepository<Employee>
    {
        Task<bool> IsEmployeeEmailUnique(string email);
        Task<Employee?> GetByActivationToken(Guid activationToken);
        Task<List<Employee>> ListByCompanyId(Guid companyId);
        Task<Employee?> GetByEmail(string email);
    } 
}
