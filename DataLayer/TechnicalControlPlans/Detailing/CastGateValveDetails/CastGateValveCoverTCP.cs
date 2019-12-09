using System.Collections.Generic;
using DataLayer.Journals.Detailing.CastGateValveDetails;

namespace DataLayer.TechnicalControlPlans.Detailing.CastGateValveDetails
{
    public class CastGateValveCoverTCP : BaseTCP
    {
        public IEnumerable<CastGateValveCoverJournal> CastGateValveCoverJournals { get; set; }
    }
}
