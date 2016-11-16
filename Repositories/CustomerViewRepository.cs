using Models;
using Repositories.Base;
using System.Data.Entity;

namespace Repositories
{
    public class CustomerViewRepository : GenericReadableRepository<CustomerView>
    {
        public CustomerViewRepository(DbContext context) : base(context)
        {
        }
    }
}
