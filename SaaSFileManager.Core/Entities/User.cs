namespace SaaSFileManager.Core.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public UserRole Role { get; set; }
        public bool IsActive { get; set; }
        public int CompanyId { get; set; }
        public Company Company = new();
    }

    public enum UserRole
    {
        Admin = 0,
        Employee = 1
    }
}
