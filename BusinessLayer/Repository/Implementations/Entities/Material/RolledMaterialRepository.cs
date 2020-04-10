using BusinessLayer.Repository.Interfaces.Entities.Material;
using DataLayer;
using DataLayer.Entities.Materials;
using DataLayer.Journals.Materials;
using DataLayer.TechnicalControlPlans.Materials;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BusinessLayer.Repository.Implementations.Entities.Material
{
    public class RolledMaterialRepository : RepositoryWithJournal<RolledMaterial, RolledMaterialJournal, MetalMaterialTCP>, IRolledMaterialRepository
    {
        public RolledMaterialRepository(DataContext context) : base(context) { }

        public async Task<RolledMaterial> GetByIdIncludeAsync(int id)
        {
            return await db.RolledMaterials.Include(i => i.RolledMaterialJournals).SingleOrDefaultAsync(i => i.Id == id);
        }

        public override RolledMaterial AddCopy(RolledMaterial entity)
        {
            RolledMaterial newEntity = new RolledMaterial(entity);
            table.Add(newEntity);
            SaveChanges();
            return newEntity;
        }

        public override async Task<RolledMaterial> AddCopyAsync(RolledMaterial entity)
        {
            RolledMaterial newEntity = new RolledMaterial(entity);
            await table.AddAsync(newEntity);
            SaveChanges();
            return newEntity;
        }
    }
}
