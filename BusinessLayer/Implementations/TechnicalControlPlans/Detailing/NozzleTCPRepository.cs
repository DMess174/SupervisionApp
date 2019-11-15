using BusinessLayer.Interfaces.TechnicalControlPlans.Detailing;
using DataLayer;
using DataLayer.TechnicalControlPlans.Detailing;

namespace BusinessLayer.Implementations.TechnicalControlPlans.Detailing
{
    public class NozzleTCPRepository : Repository<NozzleTCP>, INozzleTCPRepository
    {
        public NozzleTCPRepository(DataContext context)
            : base(context)
        {
        }

        public DataContext DataContext
        {
            get { return Context as DataContext; }
        }
    }
}
