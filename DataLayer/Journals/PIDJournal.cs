using DataLayer.TechnicalControlPlans;

namespace DataLayer.Journals
{
    public class PIDJournal : BaseJournal<PID, PIDTCP>
    {
        public PIDJournal() { }

        public PIDJournal(PID entity, PIDTCP entityTCP) : base(entity, entityTCP)
        { }

        public PIDJournal(int id, PIDJournal journal) : base(id, journal)
        { }
    }
}
