using DataLayer.Entities.Detailing;
using DataLayer.TechnicalControlPlans.Detailing;

namespace DataLayer.Journals.Detailing
{
    public class SpringJournal : BaseJournal<Spring, SpringTCP>
    {
        public SpringJournal() { }

        public SpringJournal(Spring entity, SpringTCP entityTCP) : base(entity, entityTCP)
        { }

        public SpringJournal(int id, SpringJournal journal) : base(id, journal)
        { }
    }
}
