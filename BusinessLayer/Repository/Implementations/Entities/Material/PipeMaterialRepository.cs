using BusinessLayer.Repository.Interfaces.Entities.Material;
using DataLayer;
using DataLayer.Entities.Materials;
using DataLayer.Journals.Materials;
using DataLayer.TechnicalControlPlans.Materials;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BusinessLayer.Repository.Implementations.Entities.Material
{
    public class PipeMaterialRepository : RepositoryWithJournal<PipeMaterial, PipeMaterialJournal, MetalMaterialTCP>, IPipeMaterialRepository
    {
        public PipeMaterialRepository(DataContext context) : base(context) { }

        public async Task<PipeMaterial> GetByIdIncludeAsync(int id)
        {
            return await db.PipeMaterials.Include(i => i.PipeMaterialJournals).SingleOrDefaultAsync(i => i.Id == id);
        }

        public override PipeMaterial AddCopy(PipeMaterial entity)
        {
            PipeMaterial newEntity = new PipeMaterial(entity);
            table.Add(newEntity);
            SaveChanges();
            return newEntity;
        }

        public override async Task<PipeMaterial> AddCopyAsync(PipeMaterial entity)
        {
            PipeMaterial newEntity = new PipeMaterial(entity);
            await table.AddAsync(newEntity);
            SaveChanges();
            return newEntity;
        }
    }
}
