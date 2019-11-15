using BusinessLayer.Interfaces.TechnicalControlPlans.AssemblyUnits;
using DataLayer;
using DataLayer.TechnicalControlPlans.AssemblyUnits;

namespace BusinessLayer.Implementations.TechnicalControlPlans.AssemblyUnits
{
    public class ShutterReverseTCPRepository : Repository<ShutterReverseTCP>, IShutterReverseTCPRepository
    {
        public ShutterReverseTCPRepository(DataContext context)
            : base(context)
        {
        }

        public DataContext DataContext
        {
            get { return Context as DataContext; }
        }
    }
}
