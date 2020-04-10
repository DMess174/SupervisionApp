using DataLayer.Entities.Detailing.CompactGateValveDetails;
using DataLayer.TechnicalControlPlans.Detailing.WeldGateValveDetails;

namespace DataLayer.Journals.Detailing.WeldGateValveDetails
{
    public class CompactGateValveCoverJournal : BaseJournal<CompactGateValveCover, CompactGateValveCoverTCP>
    {
        public CompactGateValveCoverJournal() { }

        public CompactGateValveCoverJournal(CompactGateValveCover entity, CompactGateValveCoverTCP entityTCP) : base(entity, entityTCP)
        { }

        public CompactGateValveCoverJournal(int id, CompactGateValveCoverJournal journal) : base(id, journal)
        { }
    }
}
