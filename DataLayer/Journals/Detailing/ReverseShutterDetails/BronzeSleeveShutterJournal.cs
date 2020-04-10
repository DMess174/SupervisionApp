using DataLayer.Entities.Detailing.ReverseShutterDetails;
using DataLayer.TechnicalControlPlans.Detailing.ReverseShutterDetails;

namespace DataLayer.Journals.Detailing.ReverseShutterDetails
{
    public class BronzeSleeveShutterJournal : BaseJournal<BronzeSleeveShutter, BronzeSleeveShutterTCP>
    {
        public BronzeSleeveShutterJournal()
        {

        }
        public BronzeSleeveShutterJournal(BronzeSleeveShutter entity, BronzeSleeveShutterTCP entityTCP) : base(entity, entityTCP)
        { }

        public BronzeSleeveShutterJournal(int id, BronzeSleeveShutterJournal journal) : base(id, journal)
        { }
    }
}
