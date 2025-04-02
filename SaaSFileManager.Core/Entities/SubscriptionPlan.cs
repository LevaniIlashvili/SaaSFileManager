namespace SaaSFileManager.Core.Entities
{
    public class SubscriptionPlan
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; // Free, Basic, Premium
        public int FileLimit { get; set; }
        public int UserLimit { get; set; }
        public int Price { get; set; }
        public int ExtraFileCost { get; set; }
    }
}
