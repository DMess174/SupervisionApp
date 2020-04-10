using DataLayer.Entities.Materials;
using DataLayer.Journals.Materials;
using DataLayer.TechnicalControlPlans.Materials;
using System.Threading.Tasks;

namespace BusinessLayer.Repository.Interfaces.Entities.Material
{
    public interface IWeldingMaterialRepository : IRepository<WeldingMaterial>, IRepositoryWithJournal<WeldingMaterial, WeldingMaterialJournal, WeldingMaterialTCP>
    {
        Task<WeldingMaterial> GetByIdIncludeAsync(int id);
    }
}
