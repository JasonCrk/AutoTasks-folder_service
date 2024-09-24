using Domain.ValueObjects;

using MediatR;

namespace Application.Commands.Delete
{
    public class DeleteFolderCommand : IRequest<Unit>
    {
        public required FolderId Id { get; set; }
        public required UserId UserId { get; set; }
    }
}