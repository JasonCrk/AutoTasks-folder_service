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
    public class FolderPutRestController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPut("{id:guid}")]
        [IsAuthFilter]
        [SwaggerOperation(Summary = "Create or update a folder")]
        [SwaggerResponse(201, "The folder has been successfully created or updated")]
        [SwaggerResponse(404, "The folder doesn't exist")]
        [SwaggerResponse(403, "User doesn't own the folder")]
        public async Task<IActionResult> Create(
            Guid id,
            [FromBody] CreateFolderRequest body,
            [FromHeader(Name = "X-User-Id"), SwaggerParameter(Required = true)] string userId)
        {
            await _mediator.Send(new CreateFolderCommand
            {
                Id = new FolderId(id.ToString()),
                Name = new FolderName(body.Name),
                UserId = new UserId(userId.ToString()),
                ParentFolderId = body.FolderId is null ? null : new FolderId(body.FolderId)
            });

            return Created();
        }
    }
}