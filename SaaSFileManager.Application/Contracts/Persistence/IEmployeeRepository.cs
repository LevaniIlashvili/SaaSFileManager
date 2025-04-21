using SaaSFileManager.Domain.Entities;

namespace SaaSFileManager.Application.Contracts.Persistence
{
    public interface IEmployeeRepository : IAsyncRepository<Employee>
    {
    }
}
