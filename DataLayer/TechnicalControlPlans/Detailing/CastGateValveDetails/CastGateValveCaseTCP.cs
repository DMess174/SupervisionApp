using System.Collections.Generic;
using DataLayer.Journals.Detailing.CastGateValveDetails;

namespace DataLayer.TechnicalControlPlans.Detailing.CastGateValveDetails
{
    public class CastGateValveCaseTCP : BaseTCP
    {
        public IEnumerable<CastGateValveCaseJournal> CastGateValveCaseJournals { get; set; }
    }
}
