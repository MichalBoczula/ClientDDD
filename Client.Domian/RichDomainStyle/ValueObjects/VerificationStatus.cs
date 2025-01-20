using Client.Domian.Common;

namespace Client.Domian.RichDomainStyle.ValueObjects
{
    public record VerificationStatus : ValueObject
    {
        public string Name { get; init; }

        public VerificationStatus()
        {

        }

        public VerificationStatus(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be null or empty.", nameof(name));

            Name = name;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
        }
    }
}
