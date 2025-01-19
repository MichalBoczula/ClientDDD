using Client.Domian.Common;

namespace Client.Domian.Entities
{
    public record EmailContact : EntityBase
    {
        public Guid ClientId { get; init; }
        public string Content { get; init; }
        public string Domain { get; init; }
        public ContactSource Source { get; init; }
        public ContactChangeBasis ChangeBasis { get; init; }
        public ContactVerificationStatus VerificationStatus { get; init; }

        public EmailContact() { }

        public EmailContact(
            Guid id,
            Guid clientId,
            string content,
            string domain,
            ContactSource source,
            ContactChangeBasis changeBasis,
            ContactVerificationStatus verificationStatus)
        {
            Id = id;
            ClientId = clientId;
            Content = content;
            Domain = domain;
            Source = source;
            ChangeBasis = changeBasis;
            VerificationStatus = verificationStatus;
        }
    }
}
