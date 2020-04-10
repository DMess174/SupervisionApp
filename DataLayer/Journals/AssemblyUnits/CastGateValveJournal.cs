using DataLayer.Entities.AssemblyUnits;
using DataLayer.TechnicalControlPlans.AssemblyUnits;

namespace DataLayer.Journals.AssemblyUnits
{
    public class CastGateValveJournal : BaseJournal<CastGateValve, CastGateValveTCP>
    {
        public CastGateValveJournal()
        {

        }

        public CastGateValveJournal(CastGateValve entity, CastGateValveTCP entityTCP) : base(entity, entityTCP)
        { }

        public CastGateValveJournal(int id, CastGateValveJournal journal) : base(id, journal)
        { }
    }
}
