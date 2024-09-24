using Domain.Exceptions;
using Domain.Ports.Repositories;

using MediatR;

namespace Application.Queries.Verify
{
    public class VerifyFolderExistsQueryHandler(FolderRepository folderRepository)
        : IRequestHandler<VerifyFolderExistsQuery, Unit>
    {
        private readonly FolderRepository _folderRepository = folderRepository;

        public async Task<Unit> Handle(VerifyFolderExistsQuery request, CancellationToken cancellationToken)
        {
            bool folderExist = await _folderRepository.ExistsById(request.FolderId);

            if (!folderExist) throw new FolderNotFoundException();

            return Unit.Value;
        }
    }
}