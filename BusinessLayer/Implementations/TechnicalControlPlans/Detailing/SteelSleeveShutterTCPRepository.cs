using BusinessLayer.Interfaces.TechnicalControlPlans.Detailing;
using DataLayer;
using DataLayer.TechnicalControlPlans.Detailing.ReverseShutterDetails;

namespace BusinessLayer.Implementations.TechnicalControlPlans.Detailing
{
    public class SteelSleeveShutterTCPRepository : Repository<SteelSleeveShutterTCP>, ISteelSleeveShutterTCPRepository
    {
        public SteelSleeveShutterTCPRepository(DataContext context)
            : base(context)
        {
        }

        public DataContext DataContext => Context as DataContext;
    }
}
