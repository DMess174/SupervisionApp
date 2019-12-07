using System.Collections.Generic;
using DataLayer.Entities.Detailing.CastGateValveDetails;
using DataLayer.Journals.AssemblyUnits;

namespace DataLayer.Entities.AssemblyUnits
{
    public class CastGateValve : BaseGateValve
    {
        public CastGateValve() : base()
        {
            Name = "Задвижка шиберная";
        }

        public int? CastGateValveCaseId { get; set; }
        public CastGateValveCase CastGateValveCase { get; set; }

        public IEnumerable<CastGateValveJournal> CastGateValveJournals { get; set; }
    }
}
