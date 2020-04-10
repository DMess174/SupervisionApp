using DataLayer.Entities.Materials;
using DataLayer.TechnicalControlPlans.Materials;

namespace DataLayer.Journals.Materials
{
    public class SheetMaterialJournal : BaseJournal<SheetMaterial, MetalMaterialTCP>
    {
        public SheetMaterialJournal() { }

        public SheetMaterialJournal(SheetMaterial entity, MetalMaterialTCP entityTCP) : base(entity, entityTCP)
        { }

        public SheetMaterialJournal(int id, SheetMaterialJournal journal) : base(id, journal)
        { }
    }
}
