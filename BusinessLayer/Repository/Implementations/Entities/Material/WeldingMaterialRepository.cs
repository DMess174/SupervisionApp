using BusinessLayer.Repository.Interfaces.Entities.Material;
using DataLayer;
using DataLayer.Entities.Materials;
using DataLayer.Journals.Materials;
using DataLayer.TechnicalControlPlans.Materials;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BusinessLayer.Repository.Implementations.Entities.Material
{
    public class WeldingMaterialRepository : RepositoryWithJournal<WeldingMaterial, WeldingMaterialJournal, WeldingMaterialTCP>, IWeldingMaterialRepository
    {
        public WeldingMaterialRepository(DataContext context) : base(context) { }

        public async Task<WeldingMaterial> GetByIdIncludeAsync(int id)
        {
            return await db.WeldingMaterials.Include(i => i.WeldingMaterialJournals).SingleOrDefaultAsync(i => i.Id == id);
        }

        public override WeldingMaterial AddCopy(WeldingMaterial entity)
        {
            WeldingMaterial newEntity = new WeldingMaterial(entity);
            table.Add(newEntity);
            SaveChanges();
            return newEntity;
        }

        public override async Task<WeldingMaterial> AddCopyAsync(WeldingMaterial entity)
        {
            WeldingMaterial newEntity = new WeldingMaterial(entity);
            await table.AddAsync(newEntity);
            SaveChanges();
            return newEntity;
        }
    }
}
