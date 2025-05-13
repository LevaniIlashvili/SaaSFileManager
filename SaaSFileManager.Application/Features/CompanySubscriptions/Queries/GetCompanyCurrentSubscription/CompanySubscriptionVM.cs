namespace SaaSFileManager.Application.Features.CompanySubscriptions.Queries.GetCompanyCurrentSubscription
{
    public class CompanySubscriptionVM
    {
        public Guid Id { get; set; }

        public Guid CompanyId { get; set; }

        public Guid SubscriptionPlanId { get; set; }

        public DateTime SubscribedAt { get; set; }
    }
}
