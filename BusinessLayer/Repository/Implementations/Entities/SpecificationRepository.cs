using BusinessLayer.Repository.Interfaces.Entities;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLayer.Repository.Implementations.Entities
{
    public class SpecificationRepository : Repository<Specification>, ISpecificationRepository
    {
        public SpecificationRepository(DataContext context) : base(context) { }

        public override async Task<IList<Specification>> GetAllAsync()
        {
            await db.Specifications.Include(i => i.PIDs).ThenInclude(i => i.ProductType).OrderBy(i => i.Number).LoadAsync();
            return db.Specifications.Local.ToObservableCollection();
        }
    }
}
