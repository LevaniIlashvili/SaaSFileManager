using SaaSFileManager.Application.Contracts.Infrastructure;

namespace SaaSFileManager.Infrastructure.Services
{
    public class FileStorageService : IFileStorageService
    {
        private readonly string _baseDirectory;

        public FileStorageService()
        {
            _baseDirectory = Path.Combine(Directory.GetCurrentDirectory(), "UploadedFiles");
            if (!Directory.Exists(_baseDirectory))
                Directory.CreateDirectory(_baseDirectory);
        }

        public async Task<string> SaveFileAsync(string fileName, byte[] content)
        {
            var uniqueName = Guid.NewGuid() + "_" + fileName;
            var filePath = Path.Combine(_baseDirectory, uniqueName);

            await File.WriteAllBytesAsync(filePath, content);

            return uniqueName;
        }

        public Task DeleteFileAsync(string relativePath)
        {
            var fullPath = Path.Combine(Directory.GetCurrentDirectory(), relativePath);
        public Task DeleteFileAsync(string storagePath)
        {
            var fullPath = Path.Combine(_baseDirectory, Path.GetFileName(storagePath));

            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }

            return Task.CompletedTask;
        }
    }
}
