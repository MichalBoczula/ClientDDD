using Client.Domian.AnemicStyle.Enums;
using Client.Domian.Common;
using System.Text.RegularExpressions;

namespace Client.Domian.AnemicStyle.ValueObjects
{
    public record PhoneContact : ValueObject
    {
        public Guid ClientId { get; init; }
        public string Number { get; init; }
        public string Prefix { get; init; }
        public ContactSource Source { get; init; }
        public ContactChangeBasis ChangeBasis { get; init; }
        public ContactVerificationStatus VerificationStatus { get; init; }

        public PhoneContact() { }

        public PhoneContact(
            Guid clientId,
            string number,
            string prefix,
            ContactSource source,
            ContactChangeBasis changeBasis,
            ContactVerificationStatus verificationStatus)
        {
            if (clientId == Guid.Empty)
                throw new ArgumentException("ClientId cannot be empty.", nameof(clientId));

            if (string.IsNullOrWhiteSpace(number))
                throw new ArgumentException("Phone number is required.", nameof(number));
            if (string.IsNullOrWhiteSpace(prefix))
                throw new ArgumentException("Phone prefix is required.", nameof(prefix));

            if (!Regex.IsMatch(number, @"^\d+$"))
                throw new ArgumentException("Phone number must contain only digits.", nameof(number));

            ClientId = clientId;
            Number = number;
            Prefix = prefix;
            Source = source;
            ChangeBasis = changeBasis;
            VerificationStatus = verificationStatus;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return ClientId;
            yield return Number;
            yield return Prefix;
            yield return Source;
            yield return ChangeBasis;
            yield return VerificationStatus;
        }
    }
}