using BusinessLayer.Interfaces.Entities.Detailing;
using DataLayer;
using DataLayer.Entities.Detailing;

namespace BusinessLayer.Implementations.Entities.Detailing
{
    public class NozzleRepository : Repository<Nozzle>, INozzleRepository
    {
        public NozzleRepository(DataContext context)
            : base(context)
        {
        }

        public DataContext DataContext => Context as DataContext;
    }
}
