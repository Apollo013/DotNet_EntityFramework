using Models;
using Repositories.Base;
using System.Data.Entity;

namespace Repositories
{
    public class CustomerRepository : GenericRepository<Customer>
    {
        public CustomerRepository(DbContext context) : base(context)
        { }
    }
}
