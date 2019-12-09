using System.Collections.Generic;
using DataLayer.Journals.Detailing.WeldGateValveDetails;

namespace DataLayer.Entities.Detailing.WeldGateValveDetails
{
    public class CoverSleeve : BaseDetail
    {
        public CoverSleeve()
        {
            Name = "Втулка крышки";
        }

        public int? CoverSealingRingId { get; set; }
        public CoverSealingRing CoverSealingRing { get; set; }

        public IEnumerable<CoverSleeveJournal> CoverSleeveJournals { get; set; }
    }
}
