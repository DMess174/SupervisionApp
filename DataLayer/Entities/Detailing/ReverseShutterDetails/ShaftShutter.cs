using System.Collections.Generic;
using DataLayer.Entities.AssemblyUnits;
using DataLayer.Journals.Detailing.ReverseShutterDetails;

namespace DataLayer.Entities.Detailing.ReverseShutterDetails
{
    public class ShaftShutter : ReverseShutterDetail
    {
        public ShaftShutter()
        {
            Name = "Ось затвора";
        }

        public IEnumerable<ShaftShutterJournal> ShaftShutterJournals { get; set; }
    }
}
