using Application.Queries.Verify;
using Domain.ValueObjects;

using Swashbuckle.AspNetCore.Annotations;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.v1
{
    [ApiController]
    [Route("api/v1/folders")]
    public class FolderGetRestController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet("{id:guid}")]
        [SwaggerOperation(Summary = "Verifies that a folder exists by id")]
        [SwaggerResponse(200, "The folder exists")]
        [SwaggerResponse(404, "The folder doesn't exist")]
        public async Task<IActionResult> VerifyFolderExist(Guid id)
        {
            await _mediator.Send(new VerifyFolderExistsQuery
            {
                FolderId = new FolderId(id.ToString()),
            });

            return Ok();
        }
    }
}