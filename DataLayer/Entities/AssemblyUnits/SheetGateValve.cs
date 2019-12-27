using System.Collections.Generic;
using DataLayer.Journals.AssemblyUnits;

namespace DataLayer.Entities.AssemblyUnits
{
    public class SheetGateValve : BaseWeldValve
    {
        public SheetGateValve()
        {
            Name = "ЗШЛ";
        }

        public IEnumerable<SheetGateValveJournal> SheetGateValveJournals { get; set; }
    }
}
