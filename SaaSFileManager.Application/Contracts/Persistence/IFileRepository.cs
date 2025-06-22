using SaaSFileManager.Application.Contracts.Persistence;
using SaaSFileManager.Domain.Entities;

namespace SaaSFileManager.Application.Contracts.Infrastructure
{
    public interface IFileRepository : IAsyncRepository<CompanyFile>
    {
        Task<List<CompanyFile>> GetFilesVisibleToEmployee(Guid employeeId);
        Task<List<CompanyFile>> GetFiles();
    }
}
