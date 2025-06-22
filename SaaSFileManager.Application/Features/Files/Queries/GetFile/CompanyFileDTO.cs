namespace SaaSFileManager.Application.Features.Files.Queries.GetFile
{
    public class CompanyFileDTO
    {
        public string Name { get; set; } = string.Empty;
        public byte[] Content { get; set; }
    }
}
