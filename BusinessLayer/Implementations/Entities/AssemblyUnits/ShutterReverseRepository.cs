using BusinessLayer.Interfaces.Entities.AssemblyUnits;
using DataLayer;
using DataLayer.Entities.AssemblyUnits;

namespace BusinessLayer.Implementations.Entities.AssemblyUnits
{
    public class ShutterReverseRepository : Repository<ReverseShutter>, IShutterReverseRepository
    {
        public ShutterReverseRepository(DataContext context)
            : base(context)
        {
        }

        public DataContext DataContext => Context as DataContext;
    }
}
