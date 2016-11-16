using DataAccess.Contexts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repositories;
using System.Data.Entity;
using System.Linq;

namespace UnitTesting.CustomerViewTesting
{
    /// <summary>
    /// Summary description for WhenGettingCustomersFromCustomerView
    /// </summary>
    [TestClass]
    public class WhenGettingCustomersFromCustomerView
    {
        CustomerViewRepository _repo;
        public WhenGettingCustomersFromCustomerView()
        {
            DbContext _db = new ApplicationContext();
            _repo = new CustomerViewRepository(_db);
        }

        [TestMethod]
        public void Result_Count_Should_Not_Be_Zero()
        {
            var customers = _repo.All();
            Assert.IsTrue(customers.Any());
        }
    }
}
