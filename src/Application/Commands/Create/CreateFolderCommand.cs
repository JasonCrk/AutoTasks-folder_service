using Domain.ValueObjects;

using MediatR;

namespace Application.Commands.Create
{
    public class CreateFolderCommand : IRequest<Unit>
    {
        public required FolderName Name { get; set; }
        public required UserId UserId { get; set; }
        public FolderId? ParentFolderId { get; set; }
    }
}