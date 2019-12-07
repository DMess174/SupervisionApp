using BusinessLayer.Interfaces.Entities;
using DataLayer;

namespace BusinessLayer.Implementations.Entities
{
    public class SpecificationRepository : Repository<Specification>, ISpecificationRepository
    {
        public SpecificationRepository(DataContext context)
            : base(context)
        {
        }

        public DataContext DataContext => Context as DataContext;
    }
}
