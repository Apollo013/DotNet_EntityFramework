using Models;
using System.Data.Entity.ModelConfiguration;

namespace DataAccess.EntityConfigurations
{
    public class CustomerViewConfiguration : EntityTypeConfiguration<CustomerView>
    {
        public CustomerViewConfiguration()
        {
            ToTable("CustomerView", "Sales").HasKey(cv => cv.Id);
        }
    }
}
