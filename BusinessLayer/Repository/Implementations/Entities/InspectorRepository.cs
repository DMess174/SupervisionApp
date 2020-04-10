using BusinessLayer.Repository.Interfaces.Entities;
using DataLayer;

namespace BusinessLayer.Repository.Implementations.Entities
{
    public class InspectorRepository : Repository<Inspector>, IInspectorRepository
    {
        public InspectorRepository(DataContext context) : base(context) { }
    }
}
