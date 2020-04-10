using DataLayer;
using DataLayer.Entities.Materials.AnticorrosiveCoating;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.Repository.Implementations.Entities.Material
{
    public class BaseAnticorrosiveCoatingRepository : Repository<BaseAnticorrosiveCoating>
    {
        public BaseAnticorrosiveCoatingRepository(DataContext context) : base(context) { }

        public override async Task<IList<BaseAnticorrosiveCoating>> GetAllAsync()
        {
            await db.BaseAnticorrosiveCoatings.Include(i => i.ReverseShutterWithCoatings).Include(i => i.BaseValveWithCoatings).LoadAsync();
            return db.BaseAnticorrosiveCoatings.Local.ToObservableCollection();
        }
    }
}
