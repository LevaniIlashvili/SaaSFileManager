namespace SaaSFileManager.Application.Features.SubscriptionPlans.Queries.GetSubscriptionPlans
{
    public class SubscriptionPlanVm
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal StartingPrice { get; set; } // dol $
    }
}
