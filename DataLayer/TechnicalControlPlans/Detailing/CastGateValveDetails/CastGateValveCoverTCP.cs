using System.Collections.ObjectModel;
using DataLayer.Journals.Detailing.CastGateValveDetails;

namespace DataLayer.TechnicalControlPlans.Detailing.CastGateValveDetails
{
    public class CastGateValveCoverTCP : BaseTCP
    {
        public ObservableCollection<CastGateValveCoverJournal> CastGateValveCoverJournals { get; set; }
    }
}
