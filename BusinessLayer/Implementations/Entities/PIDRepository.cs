using BusinessLayer.Interfaces.Entities;
using DataLayer;

namespace BusinessLayer.Implementations.Entities
{
    public class PIDRepository : Repository<PID>, IPIDRepository
    {
        public PIDRepository(DataContext context)
            : base(context)
        {
        }

        public DataContext DataContext => Context as DataContext;
    }
}
