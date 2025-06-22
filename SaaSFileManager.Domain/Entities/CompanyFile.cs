using SaaSFileManager.Domain.common;

namespace SaaSFileManager.Domain.Entities
{
    public class CompanyFile : AuditableEntity
    {
        public Guid Id { get; set; }
        public string StoragePath { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public FileType Type { get; set; }
        public Guid UploadedById { get; set; }
        public Guid CompanyId { get; set; }
        public Company Company { get; set; } = default!;

        public bool IsRestricted { get; set; } = false;
        public ICollection<CompanyFileAccess> FileAccesses { get; set; } = new List<CompanyFileAccess>();
    }

    public enum FileType
    {
        csv,
        xls,
        xlsx
    }
}
