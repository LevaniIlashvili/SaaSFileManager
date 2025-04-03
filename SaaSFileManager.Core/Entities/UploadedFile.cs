namespace SaaSFileManager.Core.Entities
{
    public class UploadedFile
    {
        public int Id { get; set; }
        public string FileName { get; set; } = string.Empty;
        public byte[] FileContent { get; set; } = [];
        public int CompanyId { get; set; }
        public Company Company { get; set; } = new();
        public int UploadedById { get; set; }
        public User UploadedBy { get; set; } = new();
        public bool IsRestricted { get; set; }
        public List<User> AllowedUsers { get; set; } = [];
    }
}
