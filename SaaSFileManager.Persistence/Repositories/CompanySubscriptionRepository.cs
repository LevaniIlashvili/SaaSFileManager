using Microsoft.EntityFrameworkCore;
using SaaSFileManager.Application.Contracts.Persistence;
using SaaSFileManager.Domain.Entities;

namespace SaaSFileManager.Persistence.Repositories
{
    public class CompanySubscriptionRepository : BaseRepository<CompanySubscription>, ICompanySubscriptionRepository
    {
        public CompanySubscriptionRepository(FileManagerDbContext dbContext) : base(dbContext)
        { 
        }

        public async Task<CompanySubscription?> GetActiveSubscriptionByCompanyId(Guid companyId)
        {
            return await _dbContext.CompanySubscriptions.FirstOrDefaultAsync(cs => cs.CompanyId == companyId && cs.CanceledAt == null);
        }
    }
}
