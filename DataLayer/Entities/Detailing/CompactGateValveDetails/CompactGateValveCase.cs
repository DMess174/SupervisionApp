using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public CompactGateValveCase(CompactGateValveCase compactCase) : base(compactCase)
        {

        }

        public ObservableCollection<CompactGateValveCaseJournal> CompactGateValveCaseJournals { get; set; }
    }
}
