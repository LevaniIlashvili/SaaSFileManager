using MediatR;
using SaaSFileManager.Application.Contracts.Infrastructure;
using SaaSFileManager.Application.Contracts.Persistence;
using SaaSFileManager.Application.Exceptions;
using SaaSFileManager.Domain.Entities;

namespace SaaSFileManager.Application.Features.Files.Commands.UploadFile
{
    public class UploadFileCommandHandler : IRequestHandler<UploadFileCommand, Guid>
    {
        private readonly IAsyncRepository<CompanyFile> _fileRepository;
        private readonly IFileStorageService _fileStorageService;
        private readonly ILoggedInUserService _loggedInUserService;
        private readonly IEmployeeRepository _employeeRepository;

        public UploadFileCommandHandler(
            IAsyncRepository<CompanyFile> fileRepository,
            IFileStorageService fileStorageService,
            ILoggedInUserService loggedInUserService,
            IEmployeeRepository employeeRepository)
        {
            _fileRepository = fileRepository;
            _fileStorageService = fileStorageService;
            _loggedInUserService = loggedInUserService;
            _employeeRepository = employeeRepository;
        }

        public async Task<Guid> Handle(UploadFileCommand command, CancellationToken cancellationToken)
        {
            var storagePath = await _fileStorageService.SaveFileAsync(command.FileName, command.Content);

            var uploadedByIdGuid = Guid.Parse(_loggedInUserService.UserId);

            Guid companyId;

            if (_loggedInUserService.Role == "Company")
            {
                companyId = uploadedByIdGuid;
            } else
            {
                var employee = await _employeeRepository.GetByIdAsync(uploadedByIdGuid);
                companyId = employee.CompanyId;
            }


            var file = new CompanyFile
            {
                Id = Guid.NewGuid(),
                Name = command.FileName,
                Type = GetFileTypeFromExtension(command.FileName),
                CompanyId = companyId,
                UploadedById = uploadedByIdGuid,
                IsRestricted = command.IsRestricted,
                FileAccesses = new List<CompanyFileAccess>(),
                StoragePath = storagePath
            };

            if (command.IsRestricted && command.AccessibleEmployeeIds != null)
            {
                file.FileAccesses = command.AccessibleEmployeeIds
                    .Select(id => new CompanyFileAccess
                    {
                        Id = Guid.NewGuid(),
                        EmployeeId = id,
                        FileId = file.Id
                    })
                    .ToList();
            }

            await _fileRepository.AddAsync(file);
            return file.Id;
        }

        private FileType GetFileTypeFromExtension(string fileName)
        {
            var extension = Path.GetExtension(fileName).ToLowerInvariant().TrimStart('.');
            return extension switch
            {
                "csv" => FileType.csv,
                "xls" => FileType.xls,
                "xlsx" => FileType.xlsx,
                _ => throw new BadRequestException($"File type {extension} is not supported.")
            };
        }
    }
}
