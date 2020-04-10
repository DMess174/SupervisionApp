using DataLayer.Journals.Materials;
using System.Collections.ObjectModel;

namespace DataLayer.TechnicalControlPlans.Materials
{
    public class ControlWeldTCP : BaseTCP
    {
        public ObservableCollection<ControlWeldJournal> ControlWeldJournals { get; set; }
    }
}
