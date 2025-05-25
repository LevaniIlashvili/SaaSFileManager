namespace SaaSFileManager.Application.Contracts.Infrastructure
{
    public interface IFileStorageService
    {
        Task<string> SaveFileAsync(string fileName, byte[] content);
    }
}
