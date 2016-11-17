using Models.Base;

namespace Models
{
    public class Address : Entity
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }

        //public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        private Address() { }

        private Address(string street, string city, string county, string country, string postalCode)
        {
            Street = street;
            City = city;
            County = county;
            Country = country;
            PostalCode = postalCode;
        }

        public static Address Create(string street, string city, string county, string country, string postalCode)
        {
            return new Address(street, city, county, country, postalCode);
        }
    }
}
