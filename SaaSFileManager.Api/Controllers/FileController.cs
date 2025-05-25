using MediatR;
using Microsoft.AspNetCore.Mvc;
using SaaSFileManager.Application.Features.Files.Commands.UploadFile;

namespace SaaSFileManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FileController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile([FromForm] IFormFile file, [FromForm] bool isRestricted, [FromForm] List<Guid> employeeIds)
        {
            using var ms = new MemoryStream();
            await file.CopyToAsync(ms);
            var content = ms.ToArray();

            var command = new UploadFileCommand
            {
                FileName = file.FileName,
                Content = content,
                ContentType = file.ContentType,
                IsRestricted = isRestricted,
                AccessibleEmployeeIds = employeeIds
            };

            var fileId = await _mediator.Send(command);
            return Ok(new { FileId = fileId });
        }
    }
}
