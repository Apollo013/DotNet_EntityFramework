using Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace DataAccess.EntityConfigurations
{
    public class SalesOrderConfiguration : EntityTypeConfiguration<SalesOrder>
    {
        public SalesOrderConfiguration()
        {
            // Table
            ToTable("SalesOrders", "Sales");

            // Primary Key
            HasKey(o => o.Id);
            Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            // Properties
            Property(o => o.OrderDate).IsRequired();


            // Indexes
            Property(o => o.CustomerId).HasColumnAnnotation(IndexAnnotation.AnnotationName,
                                                            new IndexAnnotation(
                                                            new IndexAttribute("UQX_CustomerSalesOrder") { IsUnique = true, Order = 1 }));

            Property(o => o.Id).HasColumnAnnotation(IndexAnnotation.AnnotationName,
                                                    new IndexAnnotation(
                                                     new IndexAttribute("UQX_CustomerSalesOrder") { IsUnique = true, Order = 2 }));

            // Foreign Keys
            // (Customer => Many SalesOrders)
            HasRequired(o => o.Customer).WithMany(c => c.SalesOrders)
                                        .HasForeignKey(o => new { o.CustomerId })
                                        .WillCascadeOnDelete(false);
        }
    }
}
