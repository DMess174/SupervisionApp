using DataLayer.Entities.Detailing;
using DataLayer.TechnicalControlPlans.Detailing;

namespace DataLayer.Journals.Detailing
{
    public class NozzleJournal : BaseJournal<Nozzle, NozzleTCP>
    {
        public NozzleJournal() { }

        public NozzleJournal(Nozzle entity, NozzleTCP entityTCP) : base(entity, entityTCP)
        { }

        public NozzleJournal(int id, NozzleJournal journal) : base(id, journal)
        { }
    }
}
