using System.Collections.Generic;
using DataLayer.Entities.Detailing.WeldGateValveDetails;
using DataLayer.Journals.Detailing.WeldGateValveDetails;

namespace DataLayer.Entities.Detailing.CompactGateValveDetails
{
    public class CompactGateValveCase : WeldGateValveCase
    {
        public CompactGateValveCase()
        {
            Name = "Корпус ЗШК";
        }

        public IEnumerable<CompactGateValveCaseJournal> CompactGateValveCaseJournals { get; set; }
    }
}
