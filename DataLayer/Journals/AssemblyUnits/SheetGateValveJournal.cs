using DataLayer.Entities.AssemblyUnits;
using DataLayer.TechnicalControlPlans.AssemblyUnits;

namespace DataLayer.Journals.AssemblyUnits
{
    public class SheetGateValveJournal : BaseJournal<SheetGateValve, SheetGateValveTCP>
    {
        public SheetGateValveJournal()
        {

        }
        public SheetGateValveJournal(SheetGateValve entity, SheetGateValveTCP entityTCP) : base(entity, entityTCP)
        { }

        public SheetGateValveJournal(int id, SheetGateValveJournal journal) : base(id, journal)
        { }
    }
}
