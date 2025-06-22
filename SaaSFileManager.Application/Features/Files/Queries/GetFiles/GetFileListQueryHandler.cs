using AutoMapper;
using MediatR;
using SaaSFileManager.Application.Contracts.Infrastructure;
using SaaSFileManager.Domain.Entities;

namespace SaaSFileManager.Application.Features.Files.Queries.GetFiles
{
    public class GetFileListQueryHandler : IRequestHandler<GetFileListQuery, List<ListFileVM>>
    {
        private readonly IFileRepository _fileRepository;
        private readonly ILoggedInUserService _loggedInUserService;
        private readonly IMapper _mapper;

        public GetFileListQueryHandler(
            IFileRepository fileRepository,
            ILoggedInUserService loggedInUserService,
            IMapper mapper)
        {
            _fileRepository = fileRepository;
            _loggedInUserService = loggedInUserService;
            _mapper = mapper;
        }

        public async Task<List<ListFileVM>> Handle(GetFileListQuery query, CancellationToken cancellationToken)
        {
            var userId = _loggedInUserService.UserId;
            var role = _loggedInUserService.Role;

            List<CompanyFile> files = [];
            if (role == "Employee")
            {
                files = await _fileRepository.GetFilesVisibleToEmployee(Guid.Parse(userId));
            }

            if (role == "Company")
            {
                files = await _fileRepository.GetFiles();
            }

            return _mapper.Map<List<ListFileVM>>(files);
        }
    }
}
