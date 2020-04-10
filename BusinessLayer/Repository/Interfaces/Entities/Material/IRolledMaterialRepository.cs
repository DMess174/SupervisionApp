using DataLayer.Entities.Materials;
using DataLayer.Journals.Materials;
using DataLayer.TechnicalControlPlans.Materials;
using System.Threading.Tasks;

namespace BusinessLayer.Repository.Interfaces.Entities.Material
{
    public interface IRolledMaterialRepository : IRepository<RolledMaterial>, IRepositoryWithJournal<RolledMaterial, RolledMaterialJournal, MetalMaterialTCP>
    {
        Task<RolledMaterial> GetByIdIncludeAsync(int id);
    }
}
