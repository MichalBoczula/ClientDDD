using Client.Domian.Common;
using System.Text.RegularExpressions;

namespace Client.Domian.RichDomainStyle.ValueObjects
{
    public record RichEmail : ValueObject
    {
        public Guid ClientId { get; init; }
        public string Content { get; init; }
        public string Domain { get; init; }

        public RichEmail() { }

        public RichEmail(
            Guid clientId,
            string content,
            string domain)
        {
            if (clientId == Guid.Empty)
                throw new ArgumentException("ClientId cannot be empty.", nameof(clientId));

            if (string.IsNullOrWhiteSpace(content))
                throw new ArgumentException("Email content (user part) is required.", nameof(content));
            if (string.IsNullOrWhiteSpace(domain))
                throw new ArgumentException("Email domain is required.", nameof(domain));

            if (!Regex.IsMatch(domain, @"^[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
                throw new ArgumentException("Invalid email domain format.", nameof(domain));

            ClientId = clientId;
            Content = content;
            Domain = domain;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return ClientId;
            yield return Content;
            yield return Domain;
        }
    }
}
