using DataLayer;
using DataLayer.TechnicalControlPlans;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.Repository.Implementations.Entities
{
    public class TCPRepository<T> : Repository<T>
        where T : BaseTCP, new()
    {
        public TCPRepository(DataContext context) : base(context) { }

        public override async Task<IList<T>> GetAllAsync()
        {
            await db.Set<T>().Include(i => i.OperationType).LoadAsync();
            return db.Set<T>().Local.ToObservableCollection();
        }
    }
}
