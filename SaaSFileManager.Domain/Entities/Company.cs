using SaaSFileManager.Domain.common;

namespace SaaSFileManager.Domain.Entities
{
    public class Company : AuditableEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string Industry { get; set; } = string.Empty;
        public bool IsActivated { get; set; }
        public string? ActivationToken { get; set; }

        public ICollection<Employee> Employees { get; set; } = new List<Employee>();

        public ICollection<CompanyFile> Files { get; set; } = new List<CompanyFile>();

        public Guid? CompanySubscriptionPlanId { get; set; }
        public CompanySubscription? CompanySubscription { get; set; }
    }
}
