using Models.Base;
using System;
using System.Collections.Generic;

namespace Models
{
    public class Customer : Entity
    {
        public string Name { get; private set; }

        public string WorkEmail { get; private set; }

        public string HomeEmail { get; private set; }

        public string WorkPhone { get; private set; }

        public string HomePhone { get; private set; }

        public DateTime CreateDate { get; private set; } = DateTime.Now;

        public Address Address { get; set; }

        public ICollection<SalesOrder> SalesOrders { get; private set; } = new List<SalesOrder>();

        private Customer() { }
        private Customer(string name, string homeEmail, string homePhone, string workEmail, string workPhone)
        {
            Name = name;
            HomeEmail = homeEmail;
            HomePhone = homePhone;
            WorkEmail = workEmail;
            WorkPhone = workPhone;
        }

        public static Customer Create(string name, string homeEmail, string homePhone, string workEmail, string workPhone)
        {
            return new Customer(name, homeEmail, homePhone, workEmail, workPhone);
        }

        public void AddSalesOrder(SalesOrder order)
        {
            SalesOrders.Add(order);
        }
    }
}
