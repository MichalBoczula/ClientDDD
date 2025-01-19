using Client.Domian.Common;

namespace Client.Domian.Entities
{
    public record Client : EntityBase
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string Pesel { get; init; }
        public DateTime BirthDate { get; init; }

        public IReadOnlyCollection<PhoneContact> PhoneContacts { get; init; }
        public IReadOnlyCollection<AddressContact> AddressContacts { get; init; }
        public IReadOnlyCollection<EmailContact> EmailContacts { get; init; }

        public Client()
        {
            PhoneContacts = Array.Empty<PhoneContact>();
            AddressContacts = Array.Empty<AddressContact>();
            EmailContacts = Array.Empty<EmailContact>();
        }

        public Client(
            Guid id,
            string firstName,
            string lastName,
            string pesel,
            DateTime birthDate,
            IReadOnlyCollection<PhoneContact> phoneContacts,
            IReadOnlyCollection<AddressContact> addressContacts,
            IReadOnlyCollection<EmailContact> emailContacts)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Pesel = pesel;
            BirthDate = birthDate;
            PhoneContacts = phoneContacts ?? Array.Empty<PhoneContact>();
            AddressContacts = addressContacts ?? Array.Empty<AddressContact>();
            EmailContacts = emailContacts ?? Array.Empty<EmailContact>();
        }
    }
}
