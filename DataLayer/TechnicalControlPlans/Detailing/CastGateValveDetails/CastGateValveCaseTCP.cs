using System.Collections.ObjectModel;
using DataLayer.Journals.Detailing.CastGateValveDetails;

namespace DataLayer.TechnicalControlPlans.Detailing.CastGateValveDetails
{
    public class CastGateValveCaseTCP : BaseTCP
    {
        public ObservableCollection<CastGateValveCaseJournal> CastGateValveCaseJournals { get; set; }
    }
}
