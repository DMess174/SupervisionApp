using BusinessLayer.Interfaces.Entities.Detailing;
using DataLayer;
using DataLayer.Entities.Detailing.ReverseShutterDetails;

namespace BusinessLayer.Implementations.Entities.Detailing
{
    public class ShaftShutterRepository : Repository<ShaftShutter>, IShaftShutterRepository
    {
        public ShaftShutterRepository(DataContext context)
            : base(context)
        {
        }

        public DataContext DataContext => Context as DataContext;
    }
}
