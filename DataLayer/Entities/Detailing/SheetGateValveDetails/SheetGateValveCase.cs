using System.Collections.Generic;
using System.Collections.ObjectModel;
using DataLayer.Entities.Detailing.WeldGateValveDetails;
using DataLayer.Journals.Detailing.WeldGateValveDetails;

namespace DataLayer.Entities.Detailing.SheetGateValveDetails
{
    public class SheetGateValveCase : WeldGateValveCase
    {
        public SheetGateValveCase()
        {
            Name = "Корпус ЗШЛ";
        }
        public SheetGateValveCase(SheetGateValveCase sheetCase) : base(sheetCase)
        {
        }

        public ObservableCollection<SheetGateValveCaseJournal> SheetGateValveCaseJournals { get; set; }
    }
}
