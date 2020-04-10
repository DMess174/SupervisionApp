using DataLayer.Entities.Materials;
using DataLayer.Journals.Materials;
using DataLayer.TechnicalControlPlans.Materials;
using System.Threading.Tasks;

namespace BusinessLayer.Repository.Interfaces.Entities.Material
{
    public interface IPipeMaterialRepository : IRepository<PipeMaterial>, IRepositoryWithJournal<PipeMaterial, PipeMaterialJournal, MetalMaterialTCP>
    {
        Task<PipeMaterial> GetByIdIncludeAsync(int id);
    }
}
