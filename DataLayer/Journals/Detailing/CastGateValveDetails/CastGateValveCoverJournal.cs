using DataLayer.Entities.Detailing.CastGateValveDetails;
using DataLayer.TechnicalControlPlans.Detailing.CastGateValveDetails;

namespace DataLayer.Journals.Detailing.CastGateValveDetails
{
    public class CastGateValveCoverJournal : BaseJournal<CastGateValveCover, CastGateValveCoverTCP>
    {
        public CastGateValveCoverJournal()
        {

        }
        public CastGateValveCoverJournal(CastGateValveCover entity, CastGateValveCoverTCP entityTCP) : base(entity, entityTCP)
        { }

        public CastGateValveCoverJournal(int id, CastGateValveCoverJournal journal) : base(id, journal)
        { }
    }
}
