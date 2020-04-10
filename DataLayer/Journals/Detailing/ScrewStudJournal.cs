using DataLayer.Entities.Detailing;
using DataLayer.TechnicalControlPlans.Detailing;

namespace DataLayer.Journals.Detailing
{
    public class ScrewStudJournal : BaseJournal<ScrewStud, ScrewStudTCP>
    {
        public ScrewStudJournal() { }

        public ScrewStudJournal(ScrewStud entity, ScrewStudTCP entityTCP) : base(entity, entityTCP)
        { }

        public ScrewStudJournal(int id, ScrewStudJournal journal) : base(id, journal)
        { }
    }
}
