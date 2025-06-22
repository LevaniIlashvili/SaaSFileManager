using MediatR;
using Microsoft.AspNetCore.Mvc;
using SaaSFileManager.Application.Features.Files.Commands.UploadFile;
using SaaSFileManager.Application.Features.Files.Queries.GetFile;
using SaaSFileManager.Application.Features.Files.Queries.GetFiles;

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

        [HttpGet("")]
        public async Task<ActionResult<List<ListFileVM>>> GetFiles()
        {
            var query = new GetFileListQuery();
            var files = await _mediator.Send(query);

            return Ok(files);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFile([FromRoute] GetFileQuery request)
        {
            var file = await _mediator.Send(request);

            return File(file.Content, "application/octet-stream", file.Name);
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
