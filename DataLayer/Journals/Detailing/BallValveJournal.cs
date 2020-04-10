using DataLayer.Entities.Detailing;
using DataLayer.TechnicalControlPlans.Detailing;

namespace DataLayer.Journals.Detailing
{
    public class BallValveJournal : BaseJournal<BallValve, BallValveTCP>
    {
        public BallValveJournal() { }

        public BallValveJournal(BallValve entity, BallValveTCP entityTCP) : base(entity, entityTCP)
        { }

        public BallValveJournal(int id, BallValveJournal journal) : base(id, journal)
        { }
    }
}
