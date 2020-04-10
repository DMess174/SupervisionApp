using DataLayer.Entities.Materials;
using DataLayer.TechnicalControlPlans.Materials;

namespace DataLayer.Journals.Materials
{
    public class PipeMaterialJournal : BaseJournal<PipeMaterial, MetalMaterialTCP>
    {
        public PipeMaterialJournal() { }

        public PipeMaterialJournal(PipeMaterial entity, MetalMaterialTCP entityTCP) : base(entity, entityTCP)
        { }

        public PipeMaterialJournal(int id, PipeMaterialJournal journal) : base(id, journal)
        { }
    }
}
