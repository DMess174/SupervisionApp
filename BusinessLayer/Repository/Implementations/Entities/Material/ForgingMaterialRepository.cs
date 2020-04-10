using BusinessLayer.Repository.Interfaces.Entities.Material;
using DataLayer;
using DataLayer.Entities.Materials;
using DataLayer.Journals.Materials;
using DataLayer.TechnicalControlPlans.Materials;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BusinessLayer.Repository.Implementations.Entities.Material
{
    public class ForgingMaterialRepository : RepositoryWithJournal<ForgingMaterial, ForgingMaterialJournal, MetalMaterialTCP>, IForgingMaterialRepository
    {
        public ForgingMaterialRepository(DataContext context) : base(context) { }

        public async Task<ForgingMaterial> GetByIdIncludeAsync(int id)
        {
            return await db.ForgingMaterials.Include(i => i.ForgingMaterialJournals).SingleOrDefaultAsync(i => i.Id == id);
        }

        public override ForgingMaterial AddCopy(ForgingMaterial entity)
        {
            ForgingMaterial newEntity = new ForgingMaterial(entity);
            table.Add(newEntity);
            SaveChanges();
            return newEntity;
        }

        public override async Task<ForgingMaterial> AddCopyAsync(ForgingMaterial entity)
        {
            ForgingMaterial newEntity = new ForgingMaterial(entity);
            await table.AddAsync(newEntity);
            SaveChanges();
            return newEntity;
        }
    }
}
