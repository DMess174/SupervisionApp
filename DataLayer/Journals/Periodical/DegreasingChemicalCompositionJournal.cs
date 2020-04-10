using DataLayer.TechnicalControlPlans.Periodical;

namespace DataLayer.Journals.Periodical
{
    public class DegreasingChemicalCompositionJournal : BaseJournal<DegreasingChemicalCompositionTCP>
    {
        public DegreasingChemicalCompositionJournal()
        {

        }

        public DegreasingChemicalCompositionJournal(DegreasingChemicalCompositionTCP point) : base(point)
        {

        }
    }
}
