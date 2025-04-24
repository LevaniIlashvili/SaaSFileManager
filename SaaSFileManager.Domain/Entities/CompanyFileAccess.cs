namespace SaaSFileManager.Domain.Entities
{
    public class CompanyFileAccess
    {
        public int Id { get; set; }

        public Guid FileId { get; set; }
        public CompanyFile File { get; set; } = default!;

        public Guid EmployeeId {get;set; }
        public Employee Employee { get; set; } = default!;
    }
}
