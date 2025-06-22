using SaaSFileManager.Domain.Entities;

namespace SaaSFileManager.Application.Features.Files.Queries.GetFiles
{
    public class ListFileVM
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public FileType Type { get; set; }
        public Guid UploadedById { get; set; }
        public Guid CompanyId { get; set; }
    }
}
