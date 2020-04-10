using BusinessLayer.Repository.Interfaces.Entities.Material;
using DataLayer;
using DataLayer.Entities.Materials;
using DataLayer.Journals.Materials;
using DataLayer.TechnicalControlPlans.Materials;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BusinessLayer.Repository.Implementations.Entities.Material
{
    public class SheetMaterialRepository : RepositoryWithJournal<SheetMaterial, SheetMaterialJournal, MetalMaterialTCP>, ISheetMaterialRepository
    {
        public SheetMaterialRepository(DataContext context) : base(context) { }

        public async Task<SheetMaterial> GetByIdIncludeAsync(int id)
        {
            return await db.SheetMaterials.Include(i => i.SheetMaterialJournals).SingleOrDefaultAsync(i => i.Id == id);
        }

        public override SheetMaterial AddCopy(SheetMaterial entity)
        {
            SheetMaterial newEntity = new SheetMaterial(entity);
            table.Add(newEntity);
            SaveChanges();
            return newEntity;
        }

        public override async Task<SheetMaterial> AddCopyAsync(SheetMaterial entity)
        {
            SheetMaterial newEntity = new SheetMaterial(entity);
            await table.AddAsync(newEntity);
            SaveChanges();
            return newEntity;
        }
    }
}
