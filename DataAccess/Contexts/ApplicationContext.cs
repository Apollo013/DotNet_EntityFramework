using Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;

namespace DataAccess.Contexts
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<SalesOrder> SalesOrders { get; set; }

        public ApplicationContext() : base("name=DefaultConnection")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Customer
            modelBuilder.Entity<Customer>().HasKey(c => c.Id);
            modelBuilder.Entity<Customer>().Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Customer>().Property(c => c.Name).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Customer>().Property(c => c.HomeEmail)
                                           .IsRequired().HasMaxLength(50)
                                           .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                                                                new IndexAnnotation(
                                                                new IndexAttribute("UQX_CustomerEmail") { IsUnique = true }));

            // Sales Order
            modelBuilder.Entity<SalesOrder>().HasKey(o => o.Id);
            modelBuilder.Entity<SalesOrder>().Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<SalesOrder>().Property(o => o.OrderDate).IsRequired();

            modelBuilder.Entity<SalesOrder>().Property(o => o.CustomerId)
                                             .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                                                                  new IndexAnnotation(
                                                                  new IndexAttribute("UQX_CustomerSalesOrder") { IsUnique = true, Order = 1 }));

            modelBuilder.Entity<SalesOrder>().Property(o => o.Id)
                                             .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                                                                  new IndexAnnotation(
                                                                  new IndexAttribute("UQX_CustomerSalesOrder") { IsUnique = true, Order = 2 }));

            modelBuilder.Entity<SalesOrder>().HasRequired(o => o.Customer)
                                             .WithMany(c => c.SalesOrders)
                                             .HasForeignKey(o => new { o.CustomerId })
                                             .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}
