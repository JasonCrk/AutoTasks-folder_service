using Domain.ValueObjects;

using MediatR;

namespace Application.Queries.Verify
{
    public class VerifyFolderExistsQuery : IRequest<Unit>
    {
        public required FolderId FolderId { get; set; }
    }
}