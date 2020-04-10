using DataLayer.Entities.Detailing;
using DataLayer.TechnicalControlPlans.Detailing;

namespace DataLayer.Journals.Detailing
{
    public class RunningSleeveJournal : BaseJournal<RunningSleeve, RunningSleeveTCP>
    {
        public RunningSleeveJournal() { }

        public RunningSleeveJournal(RunningSleeve entity, RunningSleeveTCP entityTCP) : base(entity, entityTCP)
        { }

        public RunningSleeveJournal(int id, RunningSleeveJournal journal) : base(id, journal)
        { }
    }
}
