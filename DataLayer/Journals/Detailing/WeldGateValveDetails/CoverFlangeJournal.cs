using DataLayer.Entities.Detailing.WeldGateValveDetails;
using DataLayer.TechnicalControlPlans.Detailing.WeldGateValveDetails;

namespace DataLayer.Journals.Detailing.WeldGateValveDetails
{
    public class CoverFlangeJournal : BaseJournal<CoverFlange, CoverFlangeTCP>
    {
        public CoverFlangeJournal() { }

        public CoverFlangeJournal(CoverFlange entity, CoverFlangeTCP entityTCP) : base(entity, entityTCP)
        { }

        public CoverFlangeJournal(int id, CoverFlangeJournal journal) : base(id, journal)
        { }
    }
}
