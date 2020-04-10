using System.Collections.Generic;
using System.Collections.ObjectModel;
using DataLayer.Journals.AssemblyUnits;

namespace DataLayer.Entities.AssemblyUnits
{
    public class SheetGateValve : BaseWeldValve
    {
        public SheetGateValve()
        {
            Name = "ЗШЛ";
        }
        public SheetGateValve(SheetGateValve valve) :base(valve)
        {
        }

        public ObservableCollection<SheetGateValveJournal> SheetGateValveJournals { get; set; }
    }
}
