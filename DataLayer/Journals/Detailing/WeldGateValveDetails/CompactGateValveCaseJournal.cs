using DataLayer.Entities.Detailing.CompactGateValveDetails;
using DataLayer.TechnicalControlPlans.Detailing.WeldGateValveDetails;

namespace DataLayer.Journals.Detailing.WeldGateValveDetails
{
    public class CompactGateValveCaseJournal : BaseJournal<CompactGateValveCase, CompactGateValveCaseTCP>
    {
        public CompactGateValveCaseJournal() { }

        public CompactGateValveCaseJournal(CompactGateValveCase entity, CompactGateValveCaseTCP entityTCP) : base(entity, entityTCP)
        { }

        public CompactGateValveCaseJournal(int id, CompactGateValveCaseJournal journal) : base(id, journal)
        { }
    }
}
