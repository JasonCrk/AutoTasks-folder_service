using Domain.Entities;
using Domain.Ports.Repositories;
using Domain.ValueObjects;

using Shared.Domain;

using MediatR;

namespace Application.Commands.Create
{
    public class CreateFolderCommandHandler(
        FolderRepository folderRepository,
        UuidGenerator uuidGenerator
    ) : IRequestHandler<CreateFolderCommand, Unit>
    {
        private readonly FolderRepository _folderRepository = folderRepository;
        private readonly UuidGenerator _uuidGenerator = uuidGenerator;

        public async Task<Unit> Handle(CreateFolderCommand request, CancellationToken cancellationToken)
        {
            Folder folder = Folder.Create(
                new FolderId(_uuidGenerator.Generate()),
                request.Name,
                request.UserId,
                request.ParentFolderId
            );

            await _folderRepository.Save(folder);

            return Unit.Value;
        }
    }
}