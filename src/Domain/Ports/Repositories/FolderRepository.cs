using Domain.Entities;
using Domain.ValueObjects;

namespace Domain.Ports.Repositories
{
    public interface FolderRepository
    {
        Task<Folder> Save(Folder folder);
        Task<bool> Delete(FolderId id);
        Task<bool> ExistsById(FolderId id);
        Task<Folder?> FindById(FolderId id);
        Task Update(Folder folder);
    }
}