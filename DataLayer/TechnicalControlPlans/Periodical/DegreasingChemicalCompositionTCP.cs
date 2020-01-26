using DataLayer.Journals.Periodical;
using System.Collections.Generic;

namespace DataLayer.TechnicalControlPlans.Periodical
{
    public class DegreasingChemicalCompositionTCP : BaseTCP
    {
        public IEnumerable<DegreasingChemicalCompositionJournal> DegreasingChemicalCompositionJournals { get; set; }
    }
}
