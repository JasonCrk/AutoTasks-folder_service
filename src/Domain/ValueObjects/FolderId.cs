using Shared.Domain.ValueObjects;

namespace Domain.ValueObjects
{
    public class FolderId(string value) : Uuid(value)
    {
    }
}