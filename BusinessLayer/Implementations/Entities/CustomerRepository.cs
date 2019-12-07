using BusinessLayer.Interfaces.Entities;
using DataLayer;

namespace BusinessLayer.Implementations.Entities
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(DataContext context)
            : base(context)
        {
        }

        public DataContext DataContext => Context as DataContext;
    }
}
