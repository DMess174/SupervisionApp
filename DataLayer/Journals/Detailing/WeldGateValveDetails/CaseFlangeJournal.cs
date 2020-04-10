using DataLayer.Entities.Detailing.WeldGateValveDetails;
using DataLayer.TechnicalControlPlans.Detailing.WeldGateValveDetails;

namespace DataLayer.Journals.Detailing.WeldGateValveDetails
{
    public class CaseFlangeJournal : BaseJournal<CaseFlange, CaseFlangeTCP>
    {
        public CaseFlangeJournal() { }

        public CaseFlangeJournal(CaseFlange entity, CaseFlangeTCP entityTCP) : base(entity, entityTCP)
        { }

        public CaseFlangeJournal(int id, CaseFlangeJournal journal) : base(id, journal)
        { }
    }
}
