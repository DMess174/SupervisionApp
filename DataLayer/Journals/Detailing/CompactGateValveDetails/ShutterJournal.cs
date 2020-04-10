using DataLayer.Entities.Detailing.CompactGateValveDetails;
using DataLayer.TechnicalControlPlans.Detailing.CompactGateValveDetails;

namespace DataLayer.Journals.Detailing.CompactGateValveDetails
{
    public class ShutterJournal : BaseJournal<Shutter, ShutterTCP>
    {
        public ShutterJournal()
        {

        }
        public ShutterJournal(Shutter entity, ShutterTCP entityTCP) : base(entity, entityTCP)
        { }

        public ShutterJournal(int id, ShutterJournal journal) : base(id, journal)
        { }
    }
}
