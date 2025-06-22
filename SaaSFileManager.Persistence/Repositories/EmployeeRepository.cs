using Microsoft.EntityFrameworkCore;
using SaaSFileManager.Application.Contracts.Persistence;
using SaaSFileManager.Domain.Entities;

namespace SaaSFileManager.Persistence.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(FileManagerDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> IsEmployeeEmailUnique(string email)
        {
            return !await _dbContext.Employees.AnyAsync(e => e.Email == email);
        }

        public async Task<Employee?> GetByActivationToken(Guid activationToken)
        {
            return await _dbContext.Employees.FirstOrDefaultAsync(e => e.ActivationToken == activationToken);
        }

        public async Task<List<Employee>> ListByCompanyId(Guid companyId)
        {
            return await _dbContext.Employees.Where(e => e.CompanyId == companyId).ToListAsync();
        }

        public async Task<Employee?> GetByEmail(string email)
        {
            return await _dbContext.Employees.FirstOrDefaultAsync(e => e.Email == email);
        }
    }
}
