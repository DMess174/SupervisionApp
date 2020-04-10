using System.Collections.ObjectModel;
using DataLayer.Journals.Detailing.WeldGateValveDetails;

namespace DataLayer.TechnicalControlPlans.Detailing.WeldGateValveDetails
{
    public class FrontWallTCP : BaseTCP
    {
        public ObservableCollection<FrontWallJournal> FrontWallJournals { get; set; }
    }
}
