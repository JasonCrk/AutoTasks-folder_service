using Api.Requests;
using Api.Filters;

using Application.Commands.Create;
using Domain.ValueObjects;

using Swashbuckle.AspNetCore.Annotations;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.v1
{
    [ApiController]
    [Route("api/v1/folders")]
    public class FolderPostRestController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost]
        [IsAuthFilter]
        [SwaggerOperation(Summary = "Create a folder")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(
            [FromBody] CreateFolderRequest body,
            [FromHeader(Name = "X-User-Id"), SwaggerParameter(Required = true)] string userId)
        {
            await _mediator.Send(new CreateFolderCommand
            {
                Name = new FolderName(body.Name),
                UserId = new UserId(userId.ToString()),
                ParentFolderId = body.FolderId is null ? null : new FolderId(body.FolderId)
            });

            return Created();
        }
    }
}