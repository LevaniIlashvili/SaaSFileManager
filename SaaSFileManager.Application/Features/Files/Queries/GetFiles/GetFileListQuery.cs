using MediatR;

namespace SaaSFileManager.Application.Features.Files.Queries.GetFiles
{
    public class GetFileListQuery : IRequest<List<ListFileVM>>
    {
    }
}
