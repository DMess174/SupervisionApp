using BusinessLayer.Interfaces.TechnicalControlPlans.Detailing;
using DataLayer;
using DataLayer.TechnicalControlPlans.Detailing;

namespace BusinessLayer.Implementations.TechnicalControlPlans.Detailing
{
    public class SteelSleeveShutterTCPRepository : Repository<SteelSleeveShutterTCP>, ISteelSleeveShutterTCPRepository
    {
        public SteelSleeveShutterTCPRepository(DataContext context)
            : base(context)
        {
        }

        public DataContext DataContext
        {
            get { return Context as DataContext; }
        }
    }
}
