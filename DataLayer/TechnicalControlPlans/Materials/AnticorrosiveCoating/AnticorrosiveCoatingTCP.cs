using DataLayer.Journals.Materials.AnticorrosiveCoating;
using System.Collections.Generic;

namespace DataLayer.TechnicalControlPlans.Materials.AnticorrosiveCoating
{
    public class AnticorrosiveCoatingTCP : BaseTCP
    {
        public IEnumerable<AbrasiveMaterialJournal> AbrasiveMaterialJournals { get; set; }
        public IEnumerable<AbovegroundCoatingJournal> AbovegroundCoatingJournals { get; set; }
        public IEnumerable<UndergroundCoatingJournal> UndergroundCoatingJournals { get; set; }
        public IEnumerable<UndercoatJournal> UndercoatJournals { get; set; }
    }
}
