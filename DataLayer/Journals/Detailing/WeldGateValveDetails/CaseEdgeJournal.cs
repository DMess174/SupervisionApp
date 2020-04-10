using DataLayer.Entities.Detailing.WeldGateValveDetails;
using DataLayer.TechnicalControlPlans.Detailing.WeldGateValveDetails;

namespace DataLayer.Journals.Detailing.WeldGateValveDetails
{
    public class CaseEdgeJournal : BaseJournal<CaseEdge, CaseEdgeTCP>
    {
        public CaseEdgeJournal() { }

        public CaseEdgeJournal(CaseEdge entity, CaseEdgeTCP entityTCP) : base(entity, entityTCP)
        { }

        public CaseEdgeJournal(int id, CaseEdgeJournal journal) : base(id, journal)
        { }
    }
}
