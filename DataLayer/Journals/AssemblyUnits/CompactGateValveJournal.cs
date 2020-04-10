using DataLayer.Entities.AssemblyUnits;
using DataLayer.TechnicalControlPlans.AssemblyUnits;

namespace DataLayer.Journals.AssemblyUnits
{
    public class CompactGateValveJournal : BaseJournal<CompactGateValve, CompactGateValveTCP>
    {
        public CompactGateValveJournal()
        {
            
        }
        public CompactGateValveJournal(CompactGateValve entity, CompactGateValveTCP entityTCP) : base(entity, entityTCP)
        { }

        public CompactGateValveJournal(int id, CompactGateValveJournal journal) : base(id, journal)
        { }
    }
}
