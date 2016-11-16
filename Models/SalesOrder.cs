using Models.Base;
using System;

namespace Models
{
    public class SalesOrder : Entity
    {
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public double OrderAmount { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        private SalesOrder() { }

        private SalesOrder(double orderAmount)
        {
            OrderAmount = orderAmount;
        }

        private SalesOrder(double orderAmount, Customer customer)
        {
            OrderAmount = orderAmount;
            Customer = customer;
            CustomerId = customer.Id;
        }

        public static SalesOrder Create(double orderAmount)
        {
            return new SalesOrder(orderAmount);
        }

        public static SalesOrder Create(double orderAmount, Customer customer)
        {
            return new SalesOrder(orderAmount, customer);
        }
    }
}
