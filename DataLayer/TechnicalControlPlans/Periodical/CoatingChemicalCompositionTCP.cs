using DataLayer.Journals.Periodical;
using System.Collections.ObjectModel;

namespace DataLayer.TechnicalControlPlans.Periodical
{
    public class CoatingChemicalCompositionTCP : BaseTCP
    {
        public ObservableCollection<CoatingChemicalCompositionJournal> CoatingChemicalCompositionJournals { get; set; }
    }
}
