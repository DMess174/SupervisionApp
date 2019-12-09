using System.Collections.Generic;
using DataLayer.Entities.AssemblyUnits;
using DataLayer.Journals.Detailing.CompactGateValveDetails;

namespace DataLayer.Entities.Detailing.CompactGateValveDetails
{
    public class ShutterGuide : BaseDetail
    {
        public ShutterGuide()
        {
            Name = "Направляющая затвора";
        }

        public int? ShutterId { get; set; }
        public Shutter Shutter{ get; set; }

        public IEnumerable<ShutterGuideJournal> ShutterGuideJournals { get; set; }
    }
}
