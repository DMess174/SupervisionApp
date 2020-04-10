using BusinessLayer.Repository.Interfaces.Entities;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLayer.Repository.Implementations.Entities
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(DataContext context) : base(context) { }

        public override async Task<IList<Customer>> GetAllAsync()
        {
            await db.Customers.OrderBy(i => i.Name).LoadAsync();
            return db.Customers.Local.ToObservableCollection();
        }
    }
}
