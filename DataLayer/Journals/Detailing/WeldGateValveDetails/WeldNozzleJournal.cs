using DataLayer.Entities.Detailing.WeldGateValveDetails;
using DataLayer.TechnicalControlPlans.Detailing.WeldGateValveDetails;

namespace DataLayer.Journals.Detailing.WeldGateValveDetails
{
    public class WeldNozzleJournal : BaseJournal<WeldNozzle, WeldNozzleTCP>
    {
        public WeldNozzleJournal() { }

        public WeldNozzleJournal(WeldNozzle entity, WeldNozzleTCP entityTCP) : base(entity, entityTCP)
        { }

        public WeldNozzleJournal(int id, WeldNozzleJournal journal) : base(id, journal)
        { }
    }
}
