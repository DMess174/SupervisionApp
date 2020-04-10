using DataLayer.Entities.Materials;
using DataLayer.TechnicalControlPlans.Materials;

namespace DataLayer.Journals.Materials
{
    public class ForgingMaterialJournal : BaseJournal<ForgingMaterial, MetalMaterialTCP>
    {
        public ForgingMaterialJournal() { }

        public ForgingMaterialJournal(ForgingMaterial entity, MetalMaterialTCP entityTCP) : base(entity, entityTCP)
        { }

        public ForgingMaterialJournal(int id, ForgingMaterialJournal journal) : base(id, journal)
        { }
    }
}
