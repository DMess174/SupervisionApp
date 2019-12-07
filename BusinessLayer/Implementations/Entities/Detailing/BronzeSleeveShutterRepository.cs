using BusinessLayer.Interfaces.Entities.Detailing;
using DataLayer;
using DataLayer.Entities.Detailing.ReverseShutterDetails;

namespace BusinessLayer.Implementations.Entities.Detailing
{
    public class BronzeSleeveShutterRepository : Repository<BronzeSleeveShutter>, IBronzeSleeveShutterRepository
    {
        public BronzeSleeveShutterRepository(DataContext context)
            : base(context)
        {
        }

        public DataContext DataContext => Context as DataContext;
    }
}
