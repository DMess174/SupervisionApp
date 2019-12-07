using BusinessLayer.Interfaces.Entities;
using DataLayer;

namespace BusinessLayer.Implementations.Entities
{
    public class InspectorRepository : Repository<Inspector>, IInspectorRepository
    {
        public InspectorRepository(DataContext context)
            : base(context)
        {
        }

        public DataContext DataContext => Context as DataContext;
    }
}
