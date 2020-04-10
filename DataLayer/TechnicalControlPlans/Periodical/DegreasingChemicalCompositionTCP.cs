using DataLayer.Journals.Periodical;
using System.Collections.ObjectModel;

namespace DataLayer.TechnicalControlPlans.Periodical
{
    public class DegreasingChemicalCompositionTCP : BaseTCP
    {
        public ObservableCollection<DegreasingChemicalCompositionJournal> DegreasingChemicalCompositionJournals { get; set; }
    }
}
