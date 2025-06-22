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

        public async Task<byte[]> GetFileAsync(string storagePath)
        {
            var fullPath = Path.Combine(_baseDirectory, Path.GetFileName(storagePath));

            return await File.ReadAllBytesAsync(fullPath);
        }

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
