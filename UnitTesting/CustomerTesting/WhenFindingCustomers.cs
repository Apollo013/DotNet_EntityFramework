using DataAccess.Contexts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repositories;
using System.Data.Entity;
using System.Linq;

namespace UnitTesting.CustomerTesting
{
    /// <summary>
    /// Summary description for WhenFindingCustomers
    /// </summary>
    [TestClass]
    public class WhenFindingCustomers
    {
        CustomerRepository _repo;
        public WhenFindingCustomers()
        {
            DbContext _db = new ApplicationContext();
            _repo = new CustomerRepository(_db);
        }

        [TestMethod]
        public void Should_Be_Able_To_Find_Customers_By_Email()
        {
            var customers = _repo.FindBy(c => c.HomeEmail.Contains(".com"));
            Assert.IsNotNull(customers);
        }

        [TestMethod]
        public void Should_Be_Able_To_Find_Customers_By_Work_Email_Without_Including_SalesOrders()
        {
            var customers = _repo.FindBy(c => c.WorkEmail.Contains(".com"));
            Assert.IsTrue(customers.Any(c => !c.SalesOrders.Any()));
        }

        [TestMethod]
        public void Should_Be_Able_To_Find_Customers_By_Work_Email_Including_SalesOrders()
        {
            var customers = _repo.FindByIncluding(c => c.WorkEmail.Contains(".com"), (c => c.SalesOrders));
            Assert.IsTrue(customers.Any(c => c.SalesOrders.Any()));
        }
    }
}
