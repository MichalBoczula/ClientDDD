using Client.Domian.AnemicStyle.Enums;
using Client.Domian.Common;
using System.Text.RegularExpressions;

namespace Client.Domian.AnemicStyle.ValueObjects
{
    public record EmailContact : ValueObject
    {
        public Guid ClientId { get; init; }
        public string Content { get; init; }    
        public string Domain { get; init; }     
        public ContactSource Source { get; init; }
        public ContactChangeBasis ChangeBasis { get; init; }
        public ContactVerificationStatus VerificationStatus { get; init; }

        public EmailContact() { }

        public EmailContact(
            Guid clientId,
            string content,
            string domain,
            ContactSource source,
            ContactChangeBasis changeBasis,
            ContactVerificationStatus verificationStatus)
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
            Source = source;
            ChangeBasis = changeBasis;
            VerificationStatus = verificationStatus;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return ClientId;
            yield return Content;
            yield return Domain;
            yield return Source;
            yield return ChangeBasis;
            yield return VerificationStatus;
        }
    }
}
