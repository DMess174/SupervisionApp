using System.Collections.Generic;
using System.Collections.ObjectModel;
using DataLayer.Journals.AssemblyUnits;

namespace DataLayer.Entities.AssemblyUnits
{
    public class CompactGateValve : BaseWeldValve
    {
        public CompactGateValve()
        {
            Name = "ЗШК";
        }
        public CompactGateValve(CompactGateValve valve) : base(valve)
        {

        }

        public ObservableCollection<CompactGateValveJournal> CompactGateValveJournals { get; set; }
    }
}
