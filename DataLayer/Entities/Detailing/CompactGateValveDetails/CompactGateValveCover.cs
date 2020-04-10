using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public CompactGateValveCover(CompactGateValveCover cover) : base(cover)
        {

        }

        public ObservableCollection<CompactGateValveCoverJournal> CompactGateValveCoverJournals { get; set; }
    }
}
