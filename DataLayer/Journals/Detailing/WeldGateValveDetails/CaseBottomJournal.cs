using DataLayer.Entities.Detailing.WeldGateValveDetails;
using DataLayer.TechnicalControlPlans.Detailing.WeldGateValveDetails;

namespace DataLayer.Journals.Detailing.WeldGateValveDetails
{
    public class CaseBottomJournal : BaseJournal<CaseBottom, CaseBottomTCP>
    {
        public CaseBottomJournal() { }

        public CaseBottomJournal(CaseBottom entity, CaseBottomTCP entityTCP) : base(entity, entityTCP)
        { }

        public CaseBottomJournal(int id, CaseBottomJournal journal) : base(id, journal)
        { }
    }
}
