using BusinessLayer.Interfaces.Entities.Detailing;
using DataLayer;
using DataLayer.Entities.Detailing;

namespace BusinessLayer.Implementations.Entities.Detailing
{
    public class StubShutterRepository : Repository<StubShutter>, IStubShutterRepository
    {
        public StubShutterRepository(DataContext context)
            : base(context)
        {
        }

        public DataContext DataContext
        {
            get { return Context as DataContext; }
        }
    }
}
