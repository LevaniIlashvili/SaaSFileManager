using SaaSFileManager.Domain.common;

namespace SaaSFileManager.Domain.Entities
{
    public class Employee : AuditableEntity
    {
        public Guid Id { get; set; }

        public Guid CompanyId { get; set; }
        public Company Company { get; set; } = default!;

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public string? PasswordHash { get; set; } // null until activated
        public bool IsActivated { get; set; } // false until user completes activation

        public EmployeeRole Role { get; set; } = EmployeeRole.User;
    }

    public enum EmployeeRole
    {
        Admin,
        User
    }
}
