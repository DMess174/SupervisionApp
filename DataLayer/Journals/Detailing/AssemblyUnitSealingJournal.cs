using DataLayer.Entities.Detailing;
using DataLayer.TechnicalControlPlans.Detailing;

namespace DataLayer.Journals.Detailing
{
    public class AssemblyUnitSealingJournal : BaseJournal<AssemblyUnitSealing, AssemblyUnitSealingTCP>
    {
        public AssemblyUnitSealingJournal() { }

        public AssemblyUnitSealingJournal(AssemblyUnitSealing entity, AssemblyUnitSealingTCP entityTCP) : base(entity, entityTCP)
        { }

        public AssemblyUnitSealingJournal(int id, AssemblyUnitSealingJournal journal) : base(id, journal)
        { }
    }
}
