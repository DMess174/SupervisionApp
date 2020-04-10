using DataLayer.Entities.Materials;
using DataLayer.TechnicalControlPlans.Materials;

namespace DataLayer.Journals.Materials
{
    public class RolledMaterialJournal : BaseJournal<RolledMaterial, MetalMaterialTCP>
    {
        public RolledMaterialJournal() { }

        public RolledMaterialJournal(RolledMaterial entity, MetalMaterialTCP entityTCP) : base(entity, entityTCP)
        { }

        public RolledMaterialJournal(int id, RolledMaterialJournal journal) : base(id, journal)
        { }
    }
}
