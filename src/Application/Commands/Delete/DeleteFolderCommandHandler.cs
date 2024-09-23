using Domain.Entities;
using Domain.Exceptions;
using Domain.Ports.Repositories;

using MediatR;

namespace Application.Commands.Delete
{
    public class DeleteFolderCommandHandler(FolderRepository folderRepository) : IRequestHandler<DeleteFolderCommand, Unit>
    {
        private readonly FolderRepository _folderRepository = folderRepository;

        public async Task<Unit> Handle(DeleteFolderCommand request, CancellationToken cancellationToken)
        {
            Folder folder = await _folderRepository.FindById(request.Id) ?? throw new FolderNotFoundException();

            if (!folder.UserId.Equals(request.UserId)) throw new UserNotOwnerFolderException();

            await _folderRepository.Delete(request.Id);

            return Unit.Value;
        }
    }
}