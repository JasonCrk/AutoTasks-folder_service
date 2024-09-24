using Api.Filters;

using Application.Commands.Delete;
using Domain.ValueObjects;

using Swashbuckle.AspNetCore.Annotations;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.v1
{
    [ApiController]
    [Route("api/v1/folders")]
    public class FolderDeleteRestController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpDelete("{id:guid}")]
        [IsAuthFilter]
        [SwaggerOperation(Summary = "Delete a folder by id")]
        [SwaggerResponse(204, "The folder was deleted successfully")]
        [SwaggerResponse(404, "The folder doesn't exist")]
        [SwaggerResponse(403, "User doesn't own the folder")]
        public async Task<IActionResult> DeleteFolder(
            Guid id,
            [FromHeader(Name = "X-User-Id"), SwaggerParameter(Required = true)] string userId)
        {
            await _mediator.Send(new DeleteFolderCommand
            {
                Id = new FolderId(id.ToString()),
                UserId = new UserId(userId.ToString())
            });

            return NoContent();
        }
    }
}