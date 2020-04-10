using DataLayer.Entities.Periodical;
using DataLayer.TechnicalControlPlans.Periodical;

namespace DataLayer.Journals.Periodical
{
    public class NDTControlJournal : BaseJournal<NDTControl, NDTControlTCP>
    {
        public NDTControlJournal() { }

        public NDTControlJournal(NDTControl entity, NDTControlTCP entityTCP) : base(entity, entityTCP)
        { }

        public NDTControlJournal(int id, NDTControlJournal journal) : base(id, journal)
        { }
    }
}
