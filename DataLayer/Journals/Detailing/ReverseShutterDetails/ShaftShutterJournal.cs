using DataLayer.Entities.Detailing.ReverseShutterDetails;
using DataLayer.TechnicalControlPlans.Detailing.ReverseShutterDetails;

namespace DataLayer.Journals.Detailing.ReverseShutterDetails
{
    public class ShaftShutterJournal : BaseJournal<ShaftShutter, ShaftShutterTCP>
    {
        public ShaftShutterJournal()
        {

        }
        public ShaftShutterJournal(ShaftShutter entity, ShaftShutterTCP entityTCP) : base(entity, entityTCP)
        { }

        public ShaftShutterJournal(int id, ShaftShutterJournal journal) : base(id, journal)
        { }
    }
}
