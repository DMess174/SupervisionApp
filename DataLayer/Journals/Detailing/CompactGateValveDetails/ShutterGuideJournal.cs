using DataLayer.Entities.Detailing.CompactGateValveDetails;
using DataLayer.TechnicalControlPlans.Detailing.CompactGateValveDetails;

namespace DataLayer.Journals.Detailing.CompactGateValveDetails
{
    public class ShutterGuideJournal : BaseJournal<ShutterGuide, ShutterGuideTCP>
    {
        public ShutterGuideJournal()
        {

        }
        public ShutterGuideJournal(ShutterGuide entity, ShutterGuideTCP entityTCP) : base(entity, entityTCP)
        { }

        public ShutterGuideJournal(int id, ShutterGuideJournal journal) : base(id, journal)
        { }
    }
}
