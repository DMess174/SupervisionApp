using DataLayer.Journals.Materials.AnticorrosiveCoating;
using System.Collections.ObjectModel;

namespace DataLayer.TechnicalControlPlans.Materials.AnticorrosiveCoating
{
    public class AnticorrosiveCoatingTCP : BaseTCP
    {
        public ObservableCollection<AbrasiveMaterialJournal> AbrasiveMaterialJournals { get; set; }
        public ObservableCollection<AbovegroundCoatingJournal> AbovegroundCoatingJournals { get; set; }
        public ObservableCollection<UndergroundCoatingJournal> UndergroundCoatingJournals { get; set; }
        public ObservableCollection<UndercoatJournal> UndercoatJournals { get; set; }
    }
}
