using DataLayer.Journals.Detailing;
using System.Collections.Generic;
using DataLayer.Entities.Detailing.CastGateValveDetails;
using DataLayer.Entities.Detailing.WeldGateValveDetails;

namespace DataLayer.Entities.Detailing
{
    public class CoverSealingRing : BaseDetail
    {
        public CoverSealingRing()
        {
            Name = "Уплотнительное кольцо";
        }

        public CastGateValveCover CastGateValveCover{ get; set; }
        public CoverSleeve CoverSleeve { get; set; }

        public IEnumerable<CoverSealingRingJournal> CoverSealingRingJournals{ get; set; }
    }
}
