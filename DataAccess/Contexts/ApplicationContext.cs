using DataAccess.EntityConfigurations;
using Models;
using System.Data.Entity;

namespace DataAccess.Contexts
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<SalesOrder> SalesOrders { get; set; }
        public DbSet<CustomerView> CustomerView { get; set; }

        public ApplicationContext() : base("name=DefaultConnection")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Tables
            modelBuilder.Configurations.Add(new CustomerConfiguration());
            modelBuilder.Configurations.Add(new AddressConfiguration());
            modelBuilder.Configurations.Add(new SalesOrderConfiguration());

            // Views
            modelBuilder.Configurations.Add(new CustomerViewConfiguration());

            // Base
            base.OnModelCreating(modelBuilder);
        }
    }
}
