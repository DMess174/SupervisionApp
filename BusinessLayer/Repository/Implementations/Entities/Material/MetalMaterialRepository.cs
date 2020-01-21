using BusinessLayer.Repository.Interfaces.Entities.Material;
using DataLayer;
using DataLayer.Entities.Materials;
using System.Threading.Tasks;

namespace BusinessLayer.Repository.Implementations.Entities.Material
{
    public class MetalMaterialRepository : Repository<MetalMaterial>, IMetalMaterialRepository
    {
        public MetalMaterialRepository(DataContext context) : base(context) { }
    }
}
