﻿using Client.Domian.Common;
using System.Text.RegularExpressions;

namespace Client.Domian.RichDomainStyle.AggregatesModel.ClientAggregate
{
    public record RichAddress : ValueObject
    {
        public Guid ClientId { get; init; }
        public string Street { get; init; }
        public string BuildingNumber { get; init; }
        public string ApartmentNumber { get; init; }
        public string City { get; init; }
        public string PostCode { get; init; }
        public string Country { get; init; }

        public RichAddress()
        {
        }

        public RichAddress(
            Guid clientId,
            string street,
            string buildingNumber,
            string apartmentNumber,
            string city,
            string postCode,
            string country)
        {
            if (clientId == Guid.Empty)
                throw new ArgumentException("ClientId cannot be empty.", nameof(clientId));
            if (string.IsNullOrWhiteSpace(street))
                throw new ArgumentException("Street is required.", nameof(street));
            if (string.IsNullOrWhiteSpace(buildingNumber))
                throw new ArgumentException("BuildingNumber is required.", nameof(buildingNumber));
            if (string.IsNullOrWhiteSpace(city))
                throw new ArgumentException("City is required.", nameof(city));
            if (string.IsNullOrWhiteSpace(postCode))
                throw new ArgumentException("PostCode is required.", nameof(postCode));
            if (string.IsNullOrWhiteSpace(country))
                throw new ArgumentException("Country is required.", nameof(country));

            if (!Regex.IsMatch(postCode, @"^\d{5}$"))
                throw new ArgumentException("PostCode must be 5 digits.", nameof(postCode));

            ClientId = clientId;
            Street = street;
            BuildingNumber = buildingNumber;
            ApartmentNumber = apartmentNumber;
            City = city;
            PostCode = postCode;
            Country = country;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return ClientId;
            yield return Street;
            yield return BuildingNumber;
            yield return ApartmentNumber;
            yield return City;
            yield return PostCode;
            yield return Country;
        }
    }
}