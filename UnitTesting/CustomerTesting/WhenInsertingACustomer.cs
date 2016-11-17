using DataAccess.Contexts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using Repositories;
using System;
using System.Data.Entity;

namespace UnitTesting.CustomerTesting
{
    /// <summary>
    /// Summary description for WhenInsertingACustomer
    /// </summary>
    [TestClass]
    public class WhenInsertingACustomer
    {
        CustomerRepository _repo;
        public WhenInsertingACustomer()
        {
            DbContext _db = new ApplicationContext();
            _repo = new CustomerRepository(_db);
        }

        [TestMethod]
        public void Can_Insert_Without_Optional_Address()
        {
            // Arrange
            var customer = Customer.Create("Mary", GenerateFakeEmail(), "555-666-999", "m@work.com", "444-777-555");

            // Act
            _repo.Insert(customer);
            _repo.SaveChanges();

            // Assert
            Assert.AreNotEqual(0, customer.Id);
        }

        [TestMethod]
        public void Can_Insert_With_Optional_Address()
        {
            // Arrange
            var address = Address.Create("SomeStreet", "Some City", "Some County", "Some Country", "Some Postal Code");
            var customer = Customer.Create("Harry", GenerateFakeEmail(), "555-666-999", "harry@work.com", "444-777-555", address);

            // Act
            _repo.Insert(customer);
            _repo.SaveChanges();

            // Assert
            Assert.AreNotEqual(0, customer.Address.Id);
        }

        [TestMethod]
        public void Cannot_Insert_With_Existing_Email_Address()
        {
            // Arrange
            var customer = Customer.Create("Harry", "p@gmail.com", "555-666-999", "m@work.com", "444-777-555");

            // Act & Assert
            try
            {
                _repo.Insert(customer);
                _repo.SaveChanges();
                Assert.Fail();
            }
            catch
            {
                Assert.IsTrue(true);
            }
        }

        private string GenerateFakeEmail()
        {
            var gui = Guid.NewGuid().ToString();
            return gui.Substring(0, 30) + "@gmail.com";
        }

    }
}
