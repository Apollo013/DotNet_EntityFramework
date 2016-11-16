using DataAccess.Contexts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repositories;
using System.Data.Entity;
using System.Linq;

namespace UnitTesting.CustomerTesting
{
    /// <summary>
    /// Summary description for WhenGettingAllCustomers
    /// </summary>
    [TestClass]
    public class WhenGettingAllCustomers
    {
        CustomerRepository _repo;
        public WhenGettingAllCustomers()
        {
            DbContext _db = new ApplicationContext();
            _repo = new CustomerRepository(_db);
        }

        [TestMethod]
        public void Customers_Should_Be_Available()
        {
            var customers = _repo.All();
            Assert.IsTrue(customers.Any());
        }

        [TestMethod]
        public void Customers_Should_Not_Have_SalesOrders_Included()
        {
            var customers = _repo.All();
            Assert.IsTrue(customers.Any(c => !c.SalesOrders.Any()));
        }

        [TestMethod]
        public void Customers_Should_Have_SalesOrders_Included()
        {
            var customers = _repo.AllIncluding(c => c.SalesOrders);
            Assert.IsTrue(customers.Any(c => c.SalesOrders.Any()));
        }


    }
}
