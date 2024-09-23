using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Folder
    {
        public FolderId Id { get; }
        public FolderName Name { get; }
        public UserId UserId { get; }
        public FolderId? ParentFolderId { get; }
        public Folder? ParentFolder { get; }

        public Folder(
            FolderId id,
            FolderName name,
            UserId userId,
            FolderId? parentFolderId)
        {
            Id = id;
            Name = name;
            UserId = userId;
            ParentFolderId = parentFolderId;
        }

        public static Folder Create(
            FolderId id,
            FolderName name,
            UserId userId,
            FolderId? parentFolderId)
        {
            var folder = new Folder(id, name, userId, parentFolderId);
            return folder;
        }
    }
}