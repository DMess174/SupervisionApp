using System.Collections.Generic;
using DataLayer.Entities.AssemblyUnits;
using DataLayer.Entities.Materials;
using DataLayer.Journals.Detailing.ReverseShutterDetails;

namespace DataLayer.Entities.Detailing.ReverseShutterDetails
{
    public class ShaftShutter : ReverseShutterDetail
    {
        public ShaftShutter()
        {
            Name = "Ось затвора";
        }
        public ReverseShutter ReverseShutter { get; set; }

        public IEnumerable<ShaftShutterJournal> ShaftShutterJournals { get; set; }
    }
}
