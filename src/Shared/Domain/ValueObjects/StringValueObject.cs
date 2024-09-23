
namespace Shared.Domain.ValueObjects
{
    public class StringValueObject(string value) : ValueObject
    {
        public string Value { get; } = value;

        public override string ToString()
        {
            return Value;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }

        public override bool Equals(object? obj)
        {
            if (this == obj) return true;

            if (obj is not StringValueObject item) return false;

            return Value == item.Value;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Value);
        }
    }
}