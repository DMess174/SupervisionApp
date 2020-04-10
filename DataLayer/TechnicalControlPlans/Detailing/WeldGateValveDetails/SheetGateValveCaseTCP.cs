using System.Collections.ObjectModel;
using DataLayer.Journals.Detailing.WeldGateValveDetails;

namespace DataLayer.TechnicalControlPlans.Detailing.WeldGateValveDetails
{
    public class SheetGateValveCaseTCP : BaseTCP
    {
        public ObservableCollection<SheetGateValveCaseJournal> SheetGateValveCaseJournals { get; set; }
    }
}
