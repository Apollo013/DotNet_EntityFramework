using Models;
using System.Data.Entity.ModelConfiguration;

namespace DataAccess.EntityConfigurations
{
    public class AddressConfiguration : EntityTypeConfiguration<Address>
    {
        public AddressConfiguration()
        {
            // Table
            ToTable("Addresses", "Sales");

            // Primary Key
            HasKey(a => a.Id);
            //Property(a => a.Id).HasDatabaseGeneratedOption

            // Properties
            Property(a => a.Street).IsRequired().HasMaxLength(50);
            Property(a => a.City).IsRequired().HasMaxLength(50);
            Property(a => a.Country).IsRequired().HasMaxLength(50);

            // Foreign Keys
            HasRequired(a => a.Customer).WithOptional(c => c.Address);
        }
    }
}
