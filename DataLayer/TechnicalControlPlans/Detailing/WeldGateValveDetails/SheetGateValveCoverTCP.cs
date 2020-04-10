using System.Collections.ObjectModel;
using DataLayer.Journals.Detailing.WeldGateValveDetails;

namespace DataLayer.TechnicalControlPlans.Detailing.WeldGateValveDetails
{
    public class SheetGateValveCoverTCP : BaseTCP
    {
        public ObservableCollection<SheetGateValveCoverJournal> SheetGateValveCoverJournals { get; set; }
    }
}
