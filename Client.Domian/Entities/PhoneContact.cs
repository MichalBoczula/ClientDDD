using Client.Domian.Common;

namespace Client.Domian.Entities
{
    public record PhoneContact : EntityBase
    {
        public Guid ClientId { get; init; }
        public string Number { get; init; }
        public string Prefix { get; init; }
        public ContactSource Source { get; init; }
        public ContactChangeBasis ChangeBasis { get; init; }
        public ContactVerificationStatus VerificationStatus { get; init; }

        public PhoneContact() { }

        public PhoneContact(
            Guid id,
            Guid clientId,
            string number,
            string prefix,
            ContactSource source,
            ContactChangeBasis changeBasis,
            ContactVerificationStatus verificationStatus)
        {
            Id = id;
            ClientId = clientId;
            Number = number;
            Prefix = prefix;
            Source = source;
            ChangeBasis = changeBasis;
            VerificationStatus = verificationStatus;
        }
    }
}