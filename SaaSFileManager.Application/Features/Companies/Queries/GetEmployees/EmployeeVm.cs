namespace SaaSFileManager.Application.Features.Companies.Queries.GetEmployees
{
    public class EmployeeVm
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool IsActivated { get; set; } 
    }
}
