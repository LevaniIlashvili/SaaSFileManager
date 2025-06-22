using Microsoft.EntityFrameworkCore;
using SaaSFileManager.Application.Contracts.Infrastructure;
using SaaSFileManager.Domain.Entities;

namespace SaaSFileManager.Persistence.Repositories
{
    public class FileRepository : BaseRepository<CompanyFile>, IFileRepository
    {
        public FileRepository(FileManagerDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<CompanyFile>> GetFilesVisibleToEmployee(Guid employeeId)
        {
            return await _dbContext.CompanyFiles.Where(f => f.IsRestricted == false || f.FileAccesses.Any(f => f.EmployeeId == employeeId)).ToListAsync();
        }

        public async Task<List<CompanyFile>> GetFiles()
        {
            return await _dbContext.CompanyFiles.ToListAsync();
        }
    }
}
