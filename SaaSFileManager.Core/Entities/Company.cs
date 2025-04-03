namespace SaaSFileManager.Core.Entities
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string Industry { get; set; } = string.Empty;
        public bool IsActive { get; set; } = false;
        public int? SubscriptionPlanId { get; set; }
        public SubscriptionPlan? SubscriptionPlan { get; set; }

        public List<User> Users { get; set; } = [];
        public List<UploadedFile> Files { get; set; } = [];
        public Billing? Billing { get; set; }
    }
}
