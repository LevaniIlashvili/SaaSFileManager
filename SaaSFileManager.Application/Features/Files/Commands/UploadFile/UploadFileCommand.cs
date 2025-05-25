using MediatR;

namespace SaaSFileManager.Application.Features.Files.Commands.UploadFile
{
    public class UploadFileCommand : IRequest<Guid> 
    {
        public string FileName { get; set; } = string.Empty;
        public byte[] Content { get; set; } = Array.Empty<byte>();
        public string ContentType { get; set; } = string.Empty;
        public bool IsRestricted { get; set; }
        public List<Guid> AccessibleEmployeeIds { get; set; } = new();
    }
}
