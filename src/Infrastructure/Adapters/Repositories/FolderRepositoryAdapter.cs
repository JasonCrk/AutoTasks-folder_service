using Dapper;
using Domain.Entities;
using Domain.Ports.Repositories;
using Domain.ValueObjects;

using Npgsql;

namespace Infrastructure.Adapters.Repositories
{
    public class FolderRepositoryAdapter(string connectionString) : FolderRepository
    {
        private readonly string _connectionString = connectionString;

        public async Task<bool> Delete(FolderId id)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                string sql = "DELETE FROM folders WHERE id = @Id";

                await connection.ExecuteAsync(sql, new { Id = id.Value });
            }

            return true;
        }

        public async Task<Folder> Save(Folder folder)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                string sql = "INSERT INTO folders (id, name, user_id, parent_folder_id) VALUES (@Id, @Name, @UserId, @ParentFolderId)";

                await connection.ExecuteAsync(sql, new
                {
                    Id = folder.Id.Value,
                    Name = folder.Name.Value,
                    UserId = folder.UserId.Value,
                    ParentFolderId = folder.ParentFolderId
                });
            }

            return folder;
        }
    }
}