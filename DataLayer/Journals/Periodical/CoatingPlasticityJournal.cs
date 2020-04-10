using DataLayer.TechnicalControlPlans.Periodical;

namespace DataLayer.Journals.Periodical
{
    public class CoatingPlasticityJournal : BaseJournal<CoatingPlasticityTCP>
    {
        public CoatingPlasticityJournal()
        {
        }

        public CoatingPlasticityJournal(CoatingPlasticityTCP point) : base(point)
        {

        }
    }
}
