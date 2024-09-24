using Domain.Entities;
using Domain.Ports.Repositories;
using Domain.ValueObjects;

using Shared.Domain;

using MediatR;
using Domain.Exceptions;

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
            Folder? originalFolder = await _folderRepository.FindById(request.Id);

            if (originalFolder != null && !originalFolder.UserId.Equals(request.UserId))
                throw new UserNotOwnerFolderException();

            Folder folder = Folder.Create(
                originalFolder == null
                    ? new FolderId(_uuidGenerator.Generate())
                    : request.Id,
                request.Name,
                request.UserId,
                request.ParentFolderId
            );

            if (originalFolder == null)
                await _folderRepository.Save(folder);
            else
                await _folderRepository.Update(folder);

            return Unit.Value;
        }
    }
}