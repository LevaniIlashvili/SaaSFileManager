namespace SaaSFileManager.Application.Contracts.Infrastructure
{
    public interface IFileStorageService
    {
        Task<string> SaveFileAsync(string fileName, byte[] content);
        Task<byte[]> GetFileAsync(string storagePath);
        Task DeleteFileAsync(string relativePath);
    }
}
