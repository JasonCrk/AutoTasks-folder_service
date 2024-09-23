using System.ComponentModel;

namespace Shared.Domain.ValueObjects
{
    public class Uuid : ValueObject
    {
        public string Value { get; }

        public Uuid(string value)
        {
            EnsureIsValidUuid(value);
            Value = value;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }

        private static void EnsureIsValidUuid(string value)
        {
            if (!Guid.TryParse(value, out var Uuid))
                throw new InvalidEnumArgumentException($"{value} is not a valid GUID");
        }

        public override string ToString()
        {
            return Value;
        }

        public static Uuid Random()
        {
            return new Uuid(Guid.NewGuid().ToString());
        }

        public override bool Equals(object? obj)
        {
            if (this == obj) return true;

            if (obj is not Uuid item) return false;

            return Value == item.Value;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Value);
        }
    }
}