using System.Collections.Generic;
using DataLayer.Entities.AssemblyUnits;
using DataLayer.Journals.Detailing.CastGateValveDetails;

namespace DataLayer.Entities.Detailing.CastGateValveDetails
{
    public class CastGateValveCover : BaseValveCover
    {
        public string Material { get; set; }

        public string Certificate { get; set; }

        public string Melt { get; set; }

        public int? CoverSealingRingId { get; set; }
        public CoverSealingRing CoverSealingRing { get; set; }

        public CastGateValve CastGateValve { get; set; }

        public IEnumerable<CastGateValveCoverJournal> CastGateValveCoverJournals { get; set; }
    }
}
