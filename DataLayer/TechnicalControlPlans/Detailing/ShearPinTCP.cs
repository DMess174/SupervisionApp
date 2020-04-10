using DataLayer.Journals.Detailing;
using System.Collections.ObjectModel;

namespace DataLayer.TechnicalControlPlans.Detailing
{
    public class ShearPinTCP : BaseTCP
    {
        public ObservableCollection<ShearPinJournal> ShearPinJournals { get; set; }
    }
}
