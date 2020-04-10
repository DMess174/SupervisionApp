using DataLayer.Entities.Detailing;
using DataLayer.TechnicalControlPlans.Detailing;

namespace DataLayer.Journals.Detailing
{
    public class ScrewNutJournal : BaseJournal<ScrewNut, ScrewNutTCP>
    {
        public ScrewNutJournal() { }

        public ScrewNutJournal(ScrewNut entity, ScrewNutTCP entityTCP) : base(entity, entityTCP)
        { }

        public ScrewNutJournal(int id, ScrewNutJournal journal) : base(id, journal)
        { }
    }
}
