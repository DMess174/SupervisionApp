using DataLayer.Entities.Detailing;
using DataLayer.TechnicalControlPlans.Detailing;

namespace DataLayer.Journals.Detailing
{
    public class SpindleJournal : BaseJournal<Spindle, SpindleTCP>
    {
        public SpindleJournal() { }

        public SpindleJournal(Spindle entity, SpindleTCP entityTCP) : base(entity, entityTCP)
        { }

        public SpindleJournal(int id, SpindleJournal journal) : base(id, journal)
        { }
    }
}
