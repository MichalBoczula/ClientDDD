using Client.Domian.Common;

namespace Client.Domian.RichDomainStyle.AggregatesModel.ClientAggregate
{
    public class RichClient : EntityBase<int>, IAggregateRoot
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Pesel { get; private set; }
        public DateTime BirthDate { get; private set; }

        private readonly List<RichPhone> _phoneContacts = new();
        private readonly List<RichEmail> _emailContacts = new();
        private readonly List<RichAddress> _addressContacts = new();

        public IReadOnlyCollection<RichPhone> PhoneContacts => _phoneContacts.AsReadOnly();
        public IReadOnlyCollection<RichEmail> EmailContacts => _emailContacts.AsReadOnly();
        public IReadOnlyCollection<RichAddress> AddressContacts => _addressContacts.AsReadOnly();

        protected RichClient() { }

        public RichClient(string firstName, string lastName, string pesel, DateTime birthDate)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException("FirstName is required.", nameof(firstName));
            if (string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("LastName is required.", nameof(lastName));
            if (string.IsNullOrWhiteSpace(pesel))
                throw new ArgumentException("Pesel is required.", nameof(pesel));
            if (birthDate == default)
                throw new ArgumentException("BirthDate is required.", nameof(birthDate));

            FirstName = firstName;
            LastName = lastName;
            Pesel = pesel;
            BirthDate = birthDate;
        }

        #region Domain Methods

        public void AddPhoneContact(RichPhone phone)
        {
            if (phone is null)
                throw new ArgumentNullException(nameof(phone));
            
            _phoneContacts.Add(phone);
        }

        public void RemovePhoneContact(RichPhone phone)
        {
            if (!_phoneContacts.Remove(phone))
            {
                throw new InvalidOperationException("Attempted to remove a phone contact that does not exist.");
            }
        }

        public void AddEmailContact(RichEmail email)
        {
            if (email is null)
                throw new ArgumentNullException(nameof(email));

            _emailContacts.Add(email);
        }

        public void RemoveEmailContact(RichEmail email)
        {
            if (!_emailContacts.Remove(email))
            {
                throw new InvalidOperationException("Attempted to remove an email contact that does not exist.");
            }
        }

        public void AddAddressContact(RichAddress address)
        {
            if (address is null)
                throw new ArgumentNullException(nameof(address));

            _addressContacts.Add(address);
        }

        public void RemoveAddressContact(RichAddress address)
        {
            if (!_addressContacts.Remove(address))
            {
                throw new InvalidOperationException("Attempted to remove an address contact that does not exist.");
            }
        }

        public void UpdatePhoneContact(RichPhone oldPhone, RichPhone newPhone)
        {
            RemovePhoneContact(oldPhone);
            AddPhoneContact(newPhone);
        }

        public void ChangeName(string newFirstName, string newLastName)
        {
            if (string.IsNullOrWhiteSpace(newFirstName))
                throw new ArgumentException("FirstName cannot be empty.", nameof(newFirstName));
            if (string.IsNullOrWhiteSpace(newLastName))
                throw new ArgumentException("LastName cannot be empty.", nameof(newLastName));

            FirstName = newFirstName;
            LastName = newLastName;
        }

        #endregion
    }
}

