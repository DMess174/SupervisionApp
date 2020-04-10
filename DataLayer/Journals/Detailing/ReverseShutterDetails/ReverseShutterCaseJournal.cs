using DataLayer.Entities.Detailing.ReverseShutterDetails;
using DataLayer.TechnicalControlPlans.Detailing.ReverseShutterDetails;

namespace DataLayer.Journals.Detailing.ReverseShutterDetails
{
    public class ReverseShutterCaseJournal : BaseJournal<ReverseShutterCase, ReverseShutterCaseTCP>
    {
        public ReverseShutterCaseJournal()
        {

        }
        public ReverseShutterCaseJournal(ReverseShutterCase entity, ReverseShutterCaseTCP entityTCP) : base(entity, entityTCP)
        { }

        public ReverseShutterCaseJournal(int id, ReverseShutterCaseJournal journal) : base(id, journal)
        { }
    }
}
