using DataLayer.Entities.Detailing.ReverseShutterDetails;
using DataLayer.TechnicalControlPlans.Detailing.ReverseShutterDetails;

namespace DataLayer.Journals.Detailing.ReverseShutterDetails
{
    public class StubShutterJournal : BaseJournal<StubShutter, StubShutterTCP>
    {
        public StubShutterJournal()
        {

        }
        public StubShutterJournal(StubShutter entity, StubShutterTCP entityTCP) : base(entity, entityTCP)
        { }

        public StubShutterJournal(int id, StubShutterJournal journal) : base(id, journal)
        { }
    }
}
