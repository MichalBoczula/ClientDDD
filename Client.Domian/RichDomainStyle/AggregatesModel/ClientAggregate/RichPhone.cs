using Client.Domian.Common;
using System.Text.RegularExpressions;

namespace Client.Domian.RichDomainStyle.AggregatesModel.ClientAggregate
{
    public record RichPhone : ValueObject
    {
        public Guid ClientId { get; init; }
        public string Number { get; init; }
        public string Prefix { get; init; }

        public RichPhone() { }

        public RichPhone(
            Guid clientId,
            string number,
            string prefix)
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
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return ClientId;
            yield return Number;
            yield return Prefix;
        }
    }
}