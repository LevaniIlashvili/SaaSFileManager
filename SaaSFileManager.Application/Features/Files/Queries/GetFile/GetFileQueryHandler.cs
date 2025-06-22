using MediatR;
using SaaSFileManager.Application.Contracts.Infrastructure;

namespace SaaSFileManager.Application.Features.Files.Queries.GetFile
{
    public class GetFileQueryHandler : IRequestHandler<GetFileQuery, CompanyFileDTO>
    {
        private readonly IFileRepository _fileRepository;
        private readonly IFileStorageService _fileStorageService;
        private readonly ILoggedInUserService _loggedInUserService;

        public GetFileQueryHandler(
            IFileRepository fileRepository, 
            IFileStorageService fileStorageService,
            ILoggedInUserService loggedInUserService)
        {
            _fileRepository = fileRepository;
            _fileStorageService = fileStorageService;
            _loggedInUserService = loggedInUserService;
        }

        public async Task<CompanyFileDTO> Handle(GetFileQuery request, CancellationToken cancellationToken)
        {
            var userId = _loggedInUserService.UserId;
            var userRole = _loggedInUserService.Role;

            if (userRole == "Employee")
            {
                var hasAccess = await _fileRepository.HasEmployeeAccess(Guid.Parse(userId), request.Id);

                if (!hasAccess)
                {
                    throw new Exceptions.ForbiddenException("You don't have access to this resource");
                }
            }

            var file = await _fileRepository.GetByIdAsync(request.Id);

            if (file is null)
            {
                throw new Exceptions.NotFoundException("File not found");
            }

            var content = await _fileStorageService.GetFileAsync(file.StoragePath);

            if (content.Length is 0)
            {
                throw new Exceptions.NotFoundException("File not found");
            }

            var fileDTO = new CompanyFileDTO()
            {
                Content = content,
                Name = file.Name
            };

            return fileDTO;
        }
    }
}
