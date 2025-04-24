namespace SaaSFileManager.Domain.Entities
{
    public class CompanySubscription
    {
        public Guid Id { get; set; }

        public Guid CompanyId { get; set; }
        public Company Company { get; set; } = default!;

        public int SubscriptionPlanId { get; set; }
        public SubscriptionPlan SubscriptionPlan { get; set; } = default!;

        public DateTime SubscribedAt { get; set; }
        public DateTime? CanceledAt { get; set; }

        public ICollection<BillingRecord> BillingRecords { get; set; } = new List<BillingRecord>();
    }
}
