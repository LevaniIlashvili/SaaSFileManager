using SaaSFileManager.Domain.Entities;

namespace SaaSFileManager.Application.Contracts.Persistence
{
    public interface ICompanySubscriptionRepository : IAsyncRepository<CompanySubscription>
    {
        Task<CompanySubscription?> GetActiveSubscriptionByCompanyId(Guid id);
    }
}
