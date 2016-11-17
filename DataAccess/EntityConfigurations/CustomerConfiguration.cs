using Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace DataAccess.EntityConfigurations
{
    public class CustomerConfiguration : EntityTypeConfiguration<Customer>
    {
        public CustomerConfiguration()
        {
            // Table
            ToTable("Customers", "Sales");

            // Primary Key
            HasKey(c => c.Id);
            Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            // Properties
            Property(c => c.Name).IsRequired().HasMaxLength(50);
            Property(c => c.HomeEmail).IsRequired().HasMaxLength(50);

            // Indexes
            Property(c => c.HomeEmail).HasColumnAnnotation(IndexAnnotation.AnnotationName,
                                                           new IndexAnnotation(
                                                           new IndexAttribute("UQX_CustomerEmail") { IsUnique = true }));
        }
    }
}
