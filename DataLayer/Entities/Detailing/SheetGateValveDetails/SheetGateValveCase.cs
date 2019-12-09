using System.Collections.Generic;
using DataLayer.Entities.Detailing.WeldGateValveDetails;
using DataLayer.Journals.Detailing.WeldGateValveDetails;

namespace DataLayer.Entities.Detailing.SheetGateValveDetails
{
    public class SheetGateValveCase : WeldGateValveCase
    {
        public SheetGateValveCase()
        {
            Name = "Корпус";
        }

        public IEnumerable<SheetGateValveCaseJournal> SheetGateValveCaseJournals { get; set; }
    }
}
