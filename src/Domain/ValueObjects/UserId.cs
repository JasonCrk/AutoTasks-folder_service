using Shared.Domain.ValueObjects;

namespace Domain.ValueObjects
{
    public class UserId(string value) : Uuid(value)
    {
    }
}