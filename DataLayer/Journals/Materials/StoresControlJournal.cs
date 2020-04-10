using DataLayer.TechnicalControlPlans.Materials;

namespace DataLayer.Journals.Materials
{
    public class StoresControlJournal : BaseJournal<StoresControlTCP>
    {
        public StoresControlJournal()
        {
        }

        public StoresControlJournal(StoresControlTCP point) : base(point)
        {

        }
    }
}
