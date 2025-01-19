using Client.Domian.Common;

namespace Client.Domian.Entities
{
    public record AddressContact : EntityBase
    {
        public Guid ClientId { get; init; }
        public string Street { get; init; }
        public string BuildingNumber { get; init; }
        public string ApartmentNumber { get; init; }
        public string City { get; init; }
        public string PostCode { get; init; }
        public string Country { get; init; }
        public ContactSource Source { get; init; }
        public ContactChangeBasis ChangeBasis { get; init; }
        public ContactVerificationStatus VerificationStatus { get; init; }

        public AddressContact() { }

        public AddressContact(
            Guid id,
            Guid clientId,
            string street,
            string buildingNumber,
            string apartmentNumber,
            string city,
            string postCode,
            string country,
            ContactSource source,
            ContactChangeBasis changeBasis,
            ContactVerificationStatus verificationStatus)
        {
            Id = id;
            ClientId = clientId;
            Street = street;
            BuildingNumber = buildingNumber;
            ApartmentNumber = apartmentNumber;
            City = city;
            PostCode = postCode;
            Country = country;
            Source = source;
            ChangeBasis = changeBasis;
            VerificationStatus = verificationStatus;
        }
    }
}