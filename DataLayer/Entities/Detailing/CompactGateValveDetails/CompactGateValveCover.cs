using System.Collections.Generic;
using DataLayer.Entities.Detailing.WeldGateValveDetails;
using DataLayer.Journals.Detailing.WeldGateValveDetails;

namespace DataLayer.Entities.Detailing.CompactGateValveDetails
{
    public class CompactGateValveCover : WeldGateValveCover
    {
        public CompactGateValveCover()
        {
            Name = "Крышка ЗШК";
        }

        public IEnumerable<CompactGateValveCoverJournal> CompactGateValveCoverJournals { get; set; }
    }
}
