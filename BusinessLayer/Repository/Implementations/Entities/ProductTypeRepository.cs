using BusinessLayer.Repository.Interfaces.Entities;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLayer.Repository.Implementations.Entities
{
    public class ProductTypeRepository : Repository<ProductType>, IProductTypeRepository
    {
        public ProductTypeRepository(DataContext context) : base(context) { }

        public override async Task<IList<ProductType>> GetAllAsync()
        {
            await db.ProductTypes.OrderBy(i => i.Name).LoadAsync();
            return db.ProductTypes.Local.ToObservableCollection();
        }
    }
}
