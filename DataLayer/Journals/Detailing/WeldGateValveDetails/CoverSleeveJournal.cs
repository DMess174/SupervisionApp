using DataLayer.Entities.Detailing.WeldGateValveDetails;
using DataLayer.TechnicalControlPlans.Detailing.WeldGateValveDetails;

namespace DataLayer.Journals.Detailing.WeldGateValveDetails
{
    public class CoverSleeveJournal : BaseJournal<CoverSleeve, CoverSleeveTCP>
    {
        public CoverSleeveJournal() { }

        public CoverSleeveJournal(CoverSleeve entity, CoverSleeveTCP entityTCP) : base(entity, entityTCP)
        { }

        public CoverSleeveJournal(int id, CoverSleeveJournal journal) : base(id, journal)
        { }
    }
}
