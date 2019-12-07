using BusinessLayer.Interfaces.TechnicalControlPlans.Detailing;
using DataLayer;
using DataLayer.TechnicalControlPlans.Detailing.ReverseShutterDetails;

namespace BusinessLayer.Implementations.TechnicalControlPlans.Detailing
{
    public class SlamShutterTCPRepository : Repository<SlamShutterTCP>, ISlamShutterTCPRepository
    {
        public SlamShutterTCPRepository(DataContext context)
            : base(context)
        {
        }

        public DataContext DataContext => Context as DataContext;
    }
}
