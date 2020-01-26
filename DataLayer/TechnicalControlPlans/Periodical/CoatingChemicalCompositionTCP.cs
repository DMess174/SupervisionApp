using DataLayer.Journals.Periodical;
using System.Collections.Generic;

namespace DataLayer.TechnicalControlPlans.Periodical
{
    public class CoatingChemicalCompositionTCP : BaseTCP
    {
        public IEnumerable<CoatingChemicalCompositionJournal> CoatingChemicalCompositionJournals { get; set; }
    }
}
