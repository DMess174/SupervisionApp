using DataLayer.Entities.Detailing.ReverseShutterDetails;
using DataLayer.TechnicalControlPlans.Detailing.ReverseShutterDetails;

namespace DataLayer.Journals.Detailing.ReverseShutterDetails
{
    public class SlamShutterJournal : BaseJournal<SlamShutter, SlamShutterTCP>
    {
        public SlamShutterJournal()
        {

        }
        public SlamShutterJournal(SlamShutter entity, SlamShutterTCP entityTCP) : base(entity, entityTCP)
        { }

        public SlamShutterJournal(int id, SlamShutterJournal journal) : base(id, journal)
        { }
    }
}
