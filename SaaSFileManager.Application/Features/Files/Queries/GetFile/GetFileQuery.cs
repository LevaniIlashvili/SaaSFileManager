using MediatR;

namespace SaaSFileManager.Application.Features.Files.Queries.GetFile
{
    public class GetFileQuery : IRequest<CompanyFileDTO>
    {
        public Guid Id { get; set; }
    }
}
