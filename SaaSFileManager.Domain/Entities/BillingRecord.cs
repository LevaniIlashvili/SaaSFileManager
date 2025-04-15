using SaaSFileManager.Domain.common;

namespace SaaSFileManager.Domain.Entities
{
    public class BillingRecord : AuditableEntity
    {
        public Guid Id { get; set; }
        
        public Guid CompanySubscriptionId { get; set; }
        public CompanySubscription CompanySubscription { get; set; } = default!;

        public decimal AmountDue { get; set; }
        public decimal? AmountPaid { get; set; }

        public DateTime BillingPeriod { get; set; }

        public DateTime PaidAt { get; set; }

        public int TotalEmployeesThisMonth { get; set; }
        public int TotalFilesUploadedThisMonth { get; set; }
    }
}
