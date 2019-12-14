using System.Collections.Generic;
using DataLayer.Journals.Detailing.CompactGateValveDetails;

namespace DataLayer.Entities.Detailing.CompactGateValveDetails
{
    public class ShutterDisk : BaseDetail
    {
        public ShutterDisk()
        {
            Name = "Диск затвора";
        }

        public int? ShutterId { get; set; }
        public Shutter Shutter{ get; set; }

        public IEnumerable<ShutterDiskJournal> ShutterDiskJournals{ get; set; }
    }
}
