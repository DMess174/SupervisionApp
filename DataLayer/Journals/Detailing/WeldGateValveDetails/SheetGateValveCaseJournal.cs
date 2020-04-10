using DataLayer.Entities.Detailing.SheetGateValveDetails;
using DataLayer.TechnicalControlPlans.Detailing.WeldGateValveDetails;

namespace DataLayer.Journals.Detailing.WeldGateValveDetails
{
    public class SheetGateValveCaseJournal : BaseJournal<SheetGateValveCase, SheetGateValveCaseTCP>
    {
        public SheetGateValveCaseJournal() { }

        public SheetGateValveCaseJournal(SheetGateValveCase entity, SheetGateValveCaseTCP entityTCP) : base(entity, entityTCP)
        { }

        public SheetGateValveCaseJournal(int id, SheetGateValveCaseJournal journal) : base(id, journal)
        { }
    }
}
