using System.Collections.Generic;
using DataLayer.Entities.Detailing.CastGateValveDetails;
using DataLayer.Journals.AssemblyUnits;

namespace DataLayer.Entities.AssemblyUnits
{
    public class CastGateValve : BaseValve
    {
        public CastGateValve()
        {
            Name = "Задвижка шиберная";
        }

        public int? CastGateValveCaseId { get; set; }
        public CastGateValveCase CastGateValveCase { get; set; }

        public int? CastGateValveCoverId { get; set; }
        public CastGateValveCover CastGateValveCover { get; set; }

        public IEnumerable<CastGateValveJournal> CastGateValveJournals { get; set; }
    }
}
