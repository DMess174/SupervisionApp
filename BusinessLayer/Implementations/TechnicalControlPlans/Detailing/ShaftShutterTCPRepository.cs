using BusinessLayer.Interfaces.TechnicalControlPlans.Detailing;
using DataLayer;
using DataLayer.TechnicalControlPlans.Detailing.ReverseShutterDetails;

namespace BusinessLayer.Implementations.TechnicalControlPlans.Detailing
{
    public class ShaftShutterTCPRepository : Repository<ShaftShutterTCP>, IShaftShutterTCPRepository
    {
        public ShaftShutterTCPRepository(DataContext context)
            : base(context)
        {
        }

        public DataContext DataContext => Context as DataContext;
    }
}
