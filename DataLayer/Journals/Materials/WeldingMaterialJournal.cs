using DataLayer.Entities.Materials;
using DataLayer.TechnicalControlPlans.Materials;

namespace DataLayer.Journals.Materials
{
    public class WeldingMaterialJournal : BaseJournal<WeldingMaterial, WeldingMaterialTCP>
    {
        public WeldingMaterialJournal() { }

        public WeldingMaterialJournal(WeldingMaterial entity, WeldingMaterialTCP entityTCP) : base(entity, entityTCP)
        { }

        public WeldingMaterialJournal(int id, WeldingMaterialJournal journal) : base(id, journal)
        { }
    }
}
