using DataLayer.Entities.AssemblyUnits;
using DataLayer.TechnicalControlPlans.AssemblyUnits;

namespace DataLayer.Journals.AssemblyUnits
{
    public class CoatingJournal : BaseJournal<BaseAssemblyUnit, CoatingTCP>
    {
        public CoatingJournal()
        {

        }
        public CoatingJournal(BaseAssemblyUnit entity, CoatingTCP entityTCP) : base(entity, entityTCP)
        { }

        public CoatingJournal(int id, CoatingJournal journal) : base(id, journal)
        { }
    }
}
