using DataLayer.Entities.Detailing.SheetGateValveDetails;
using DataLayer.TechnicalControlPlans.Detailing.WeldGateValveDetails;

namespace DataLayer.Journals.Detailing.WeldGateValveDetails
{
    public class SheetGateValveCoverJournal : BaseJournal<SheetGateValveCover, SheetGateValveCoverTCP>
    {
        public SheetGateValveCoverJournal() { }

        public SheetGateValveCoverJournal(SheetGateValveCover entity, SheetGateValveCoverTCP entityTCP) : base(entity, entityTCP)
        { }

        public SheetGateValveCoverJournal(int id, SheetGateValveCoverJournal journal) : base(id, journal)
        { }
    }
}
