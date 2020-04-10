using DataLayer.Entities.Detailing;
using DataLayer.TechnicalControlPlans.Detailing;

namespace DataLayer.Journals.Detailing
{
    public class GateJournal : BaseJournal<Gate, GateTCP>
    {
        public GateJournal() { }

        public GateJournal(Gate entity, GateTCP entityTCP) : base(entity, entityTCP)
        { }

        public GateJournal(int id, GateJournal journal) : base(id, journal)
        { }
    }
}
