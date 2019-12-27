using System.Collections.Generic;
using DataLayer.Entities.Detailing.WeldGateValveDetails;
using DataLayer.Journals.Detailing.WeldGateValveDetails;

namespace DataLayer.Entities.Detailing.SheetGateValveDetails
{
    public class SheetGateValveCover : WeldGateValveCover
    {
        public SheetGateValveCover()
        {
            Name = "Крышка ЗШЛ";
        }

        public IEnumerable<SheetGateValveCoverJournal> SheetGateValveCoverJournals { get; set; }
    }
}
