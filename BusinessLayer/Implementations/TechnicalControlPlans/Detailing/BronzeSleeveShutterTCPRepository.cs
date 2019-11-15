using BusinessLayer.Interfaces.TechnicalControlPlans.Detailing;
using DataLayer;
using DataLayer.TechnicalControlPlans.Detailing;

namespace BusinessLayer.Implementations.TechnicalControlPlans.Detailing
{
    public class BronzeSleeveShutterTCPRepository : Repository<BronzeSleeveShutterTCP>, IBronzeSleeveShutterTCPRepository
    {
        public BronzeSleeveShutterTCPRepository(DataContext context)
            : base(context)
        {
        }

        public DataContext DataContext
        {
            get { return Context as DataContext; }
        }
    }
}
