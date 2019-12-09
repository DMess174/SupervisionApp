using System.Collections.Generic;
using DataLayer.Entities.AssemblyUnits;
using DataLayer.Journals.Detailing.CastGateValveDetails;

namespace DataLayer.Entities.Detailing.CastGateValveDetails
{
    public class CastGateValveCase : BaseCastingCase
    {
        public CastGateValveCase()
        {
            Name = "Корпус ЗШ";
        }

        public CastGateValve CastGateValve { get; set; }

        public IEnumerable<CastGateValveCaseJournal> CastGateValveCaseJournals { get; set; }
    }
}
