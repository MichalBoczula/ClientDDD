using Client.Domian.AnemicStyle.Exceptions;
using Client.Domian.AnemicStyle.ValueObjects;
using Client.Domian.Common;

namespace Client.Domian.AnemicStyle.Entities
{
    public class Client : EntityBase<int>, IAggregateRoot
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
            string firstName,
            string lastName,
            string pesel,
            DateTime birthDate,
            IReadOnlyCollection<PhoneContact> phoneContacts,
            IReadOnlyCollection<AddressContact> addressContacts,
            IReadOnlyCollection<EmailContact> emailContacts)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new DomainException("First name is required.");

            if (string.IsNullOrWhiteSpace(lastName))
                throw new DomainException("Last name is required.");

            if (string.IsNullOrWhiteSpace(pesel))
                throw new DomainException("Pesel (national ID) is required.");

            if (birthDate == default)
                throw new DomainException("Birth date is required.");


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
