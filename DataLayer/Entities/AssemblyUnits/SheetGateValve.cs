using System.Collections.Generic;
using DataLayer.Entities.Detailing;
using DataLayer.Journals.AssemblyUnits;

namespace DataLayer.Entities.AssemblyUnits
{
    public class SheetGateValve : BaseWeldValve
    {
        public SheetGateValve()
        {
            Name = "Задвижка шиберная листовая";
        }

        public IEnumerable<SheetGateValveJournal> SheetGateValveJournals { get; set; }
    }
}
