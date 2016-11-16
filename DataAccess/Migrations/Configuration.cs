namespace DataAccess.Migrations
{
    using Models;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<DataAccess.Contexts.ApplicationContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DataAccess.Contexts.ApplicationContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            var c1 = Customer.Create("Paul", "p@gmail", "(444-555-6666)", "p.work@gmail.com", "111-222-3333");
            var c2 = Customer.Create("Jamie", "j@gmail", "(444-555-777)", "j.work@gmail.com", "111-222-444");
            var c3 = Customer.Create("Gillian", "g@gmail", "(444-555-888)", "g.work@gmail.com", "111-222-555");

            var so1 = SalesOrder.Create(500.00);
            var so2 = SalesOrder.Create(600.00);
            var so3 = SalesOrder.Create(800.00);
            var so4 = SalesOrder.Create(700.00);
            var so5 = SalesOrder.Create(900.00);
            var so6 = SalesOrder.Create(1000.00);

            c1.AddSalesOrder(so1);
            c1.AddSalesOrder(so2);
            c2.AddSalesOrder(so3);
            c2.AddSalesOrder(so4);
            c3.AddSalesOrder(so5);
            c3.AddSalesOrder(so6);

            context.Customers.AddOrUpdate(c => c.HomeEmail, c1, c2, c3);

            context.SaveChanges();
        }
    }
}
