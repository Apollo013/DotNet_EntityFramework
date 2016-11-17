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
    }
}
