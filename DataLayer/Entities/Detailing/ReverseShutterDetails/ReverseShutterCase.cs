using System.Collections.Generic;
using DataLayer.Entities.AssemblyUnits;
using DataLayer.Journals.Detailing.ReverseShutterDetails;

namespace DataLayer.Entities.Detailing.ReverseShutterDetails
{
    public class ReverseShutterCase : BaseCastingCase
    {
        public ReverseShutterCase() : base()
        {
            Name = "Корпус затвора";
        }

        public ReverseShutter ReverseShutter { get; set; }

        public IEnumerable<ReverseShutterCaseJournal> ReverseShutterCaseJournals { get; set; }
    }
}
