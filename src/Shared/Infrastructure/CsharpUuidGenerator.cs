using Shared.Domain;

namespace Shared.Infrastructure
{
    public class CsharpUuidGenerator : UuidGenerator
    {
        public string Generate()
        {
            return Guid.NewGuid().ToString();
        }
    }
}