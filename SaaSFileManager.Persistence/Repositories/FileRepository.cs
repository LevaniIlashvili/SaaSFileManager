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

        public async Task<bool> HasEmployeeAccess(Guid employeeId, Guid fileId)
        {
            var file = await _dbContext.CompanyFiles.FirstAsync(f => f.Id == fileId);

            if (file.IsRestricted)
            {
                var access = _dbContext.FileAccesses.FirstOrDefault(fi => fi.FileId == fileId && fi.EmployeeId == employeeId);
                if (access is null)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
