using System.Collections.Generic;
using System.Collections.ObjectModel;
using DataLayer.Entities.AssemblyUnits;
using DataLayer.Journals.Detailing.ReverseShutterDetails;

namespace DataLayer.Entities.Detailing.ReverseShutterDetails
{
    public class ReverseShutterCase : BaseCastingCase
    {
        public ReverseShutterCase()
        {
            Name = "Корпус затвора";
        }
        public ReverseShutterCase(ReverseShutterCase shutterCase) : base(shutterCase)
        {

        }

        public ReverseShutter ReverseShutter { get; set; }

        public ObservableCollection<ReverseShutterCaseJournal> ReverseShutterCaseJournals { get; set; }
    }
}
