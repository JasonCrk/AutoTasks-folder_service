using Shared.Domain.ValueObjects;

namespace Domain.ValueObjects
{
    public class FolderName(string value) : StringValueObject(value)
    {
    }
}