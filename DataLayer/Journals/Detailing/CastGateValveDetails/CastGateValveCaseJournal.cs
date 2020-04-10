using DataLayer.Entities.Detailing.CastGateValveDetails;
using DataLayer.TechnicalControlPlans.Detailing.CastGateValveDetails;

namespace DataLayer.Journals.Detailing.CastGateValveDetails
{
    public class CastGateValveCaseJournal : BaseJournal<CastGateValveCase, CastGateValveCaseTCP>
    {
        public CastGateValveCaseJournal()
        {

        }
        public CastGateValveCaseJournal(CastGateValveCase entity, CastGateValveCaseTCP entityTCP) : base(entity, entityTCP)
        { }

        public CastGateValveCaseJournal(int id, CastGateValveCaseJournal journal) : base(id, journal)
        { }
    }
}
