using MediatR;
using SaaSFileManager.Application.Contracts.Infrastructure;

namespace SaaSFileManager.Application.Features.Files.Queries.GetFile
{
    public class GetFileQueryHandler : IRequestHandler<GetFileQuery, CompanyFileDTO>
    {
        private readonly IFileRepository _fileRepository;
        private readonly IFileStorageService _fileStorageService;

        public GetFileQueryHandler(IFileRepository fileRepository, IFileStorageService fileStorageService)
        {
            _fileRepository = fileRepository;
            _fileStorageService = fileStorageService;
        }

        public async Task<CompanyFileDTO> Handle(GetFileQuery request, CancellationToken cancellationToken)
        {
            //var user 
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
