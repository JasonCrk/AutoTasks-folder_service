using Domain.ValueObjects;

using MediatR;

namespace Application.Commands.Create
{
    public class CreateFolderCommand : IRequest<Unit>
    {
        public required FolderName Name;
        public required UserId UserId;
        public FolderId? ParentFolderId;
    }
}