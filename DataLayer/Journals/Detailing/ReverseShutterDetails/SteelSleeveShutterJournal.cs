using DataLayer.Entities.Detailing.ReverseShutterDetails;
using DataLayer.TechnicalControlPlans.Detailing.ReverseShutterDetails;

namespace DataLayer.Journals.Detailing.ReverseShutterDetails
{
    public class SteelSleeveShutterJournal : BaseJournal<SteelSleeveShutter, SteelSleeveShutterTCP>
    {
        public SteelSleeveShutterJournal()
        {

        }
        public SteelSleeveShutterJournal(SteelSleeveShutter entity, SteelSleeveShutterTCP entityTCP) : base(entity, entityTCP)
        { }

        public SteelSleeveShutterJournal(int id, SteelSleeveShutterJournal journal) : base(id, journal)
        { }
    }
}
