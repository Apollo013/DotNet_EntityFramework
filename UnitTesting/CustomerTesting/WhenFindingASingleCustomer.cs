using DataAccess.Contexts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repositories;
using System.Data.Entity;
using System.Linq;

namespace UnitTesting.CustomerTesting
{
    /// <summary>
    /// Summary description for WhenFindingASingleCustomer
    /// </summary>
    [TestClass]
    public class WhenFindingASingleCustomer
    {
        CustomerRepository _repo;
        public WhenFindingASingleCustomer()
        {
            DbContext _db = new ApplicationContext();
            _repo = new CustomerRepository(_db);
        }

        [TestMethod]
        public void Customer_Should_Not_Be_Null_When_FindingByKey_For_A_Known_Value()
        {
            var customer = _repo.FindByKey(1);
            Assert.IsNotNull(customer);
        }

        [TestMethod]
        public void Customer_Should_Be_Null_When_FindingByKey_For_An_Unknown_Value()
        {
            var customer = _repo.FindByKey(1000);
            Assert.IsNull(customer);
        }

        [TestMethod]
        public void Customer_Should_Not_Include_Related_SalesOrders_When_FindingByKey()
        {
            var customer = _repo.FindByKey(1);
            Assert.IsFalse(customer.SalesOrders.Any());
        }

        [TestMethod]
        public void Customer_Should_Not_Include_Related_SalesOrders_When_FindingByKey_Thats_Uses_LambdaExpression()
        {
            var customer = _repo.FindKey(1);
            Assert.IsFalse(customer.SalesOrders.Any());
        }
    }
}
