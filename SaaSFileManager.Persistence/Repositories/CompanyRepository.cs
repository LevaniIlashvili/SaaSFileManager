using Microsoft.EntityFrameworkCore;
using SaaSFileManager.Application.Contracts.Persistence;
using SaaSFileManager.Domain.Entities;

namespace SaaSFileManager.Persistence.Repositories
{
    public class CompanyRepository : BaseRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(FileManagerDbContext dbContext)
            : base(dbContext)
        {
        }

        public async Task<bool> IsCompanyEmailUnique(string email)
        {
            return !await _dbContext.Companies.AnyAsync(c => c.Email == email);
        }
    }
}
