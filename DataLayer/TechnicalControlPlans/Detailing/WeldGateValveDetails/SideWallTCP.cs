using System.Collections.ObjectModel;
using DataLayer.Journals.Detailing.WeldGateValveDetails;

namespace DataLayer.TechnicalControlPlans.Detailing.WeldGateValveDetails
{
    public class SideWallTCP : BaseTCP
    {
        public ObservableCollection<SideWallJournal> SideWallJournals { get; set; }
    }
}
