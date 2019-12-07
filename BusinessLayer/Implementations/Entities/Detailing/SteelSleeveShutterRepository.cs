using BusinessLayer.Interfaces.Entities.Detailing;
using DataLayer;
using DataLayer.Entities.Detailing.ReverseShutterDetails;

namespace BusinessLayer.Implementations.Entities.Detailing
{
    public class SteelSleeveShutterRepository : Repository<SteelSleeveShutter>, ISteelSleeveShutterRepository
    {
        public SteelSleeveShutterRepository(DataContext context)
            : base(context)
        {
        }

        public DataContext DataContext => Context as DataContext;
    }
}
