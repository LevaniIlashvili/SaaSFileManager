namespace SaaSFileManager.Domain.Entities
{
    public class SubscriptionPlan
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int FileLimitPerMonth { get; set; }
        public int? UserLimit { get; set; } // null = unlimited
        public decimal PricePerUser { get;set; }
        public decimal StartingPrice { get; set; } // dol $

        public bool AllowExtraFiles { get; set; }
        public decimal? PricePerExtraFile { get; set; }
    }
}
