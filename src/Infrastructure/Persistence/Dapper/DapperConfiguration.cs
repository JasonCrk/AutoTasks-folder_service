using Domain.Entities;

using Infrastructure.Persistence.Dapper.Extensions;

using Dapper;

using System.Reflection;

namespace Infrastructure.Persistence.Dapper
{
    public static class DapperConfiguration
    {
        public static void FolderEntityMapping()
        {
            SqlMapper.SetTypeMap(typeof(Folder), new CustomPropertyTypeMap(
                typeof(Folder),
                (type, columnName) =>
                {
                    string propertyName = columnName.ToPascalCase();

                    return type
                        .GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase)
                            ?? throw new InvalidOperationException($"The ${propertyName} property not found in the class ${type.Name}");
                }
            ));
        }
    }
}