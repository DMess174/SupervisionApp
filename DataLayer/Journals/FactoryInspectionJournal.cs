using DataLayer.TechnicalControlPlans;

namespace DataLayer.Journals
{
    public class FactoryInspectionJournal : BaseJournal<FactoryInspectionTCP>
    {
        public FactoryInspectionJournal()
        {

        }

        public FactoryInspectionJournal(FactoryInspectionTCP point) : base(point)
        {

        }
    }
}
