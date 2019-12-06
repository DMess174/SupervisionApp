using DataLayer.Entities.AssemblyUnits;
using DataLayer.Journals.Detailing;
using DataLayer.TechnicalControlPlans.Detailing;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Entities.Detailing
{
    public class BronzeSleeveShutter : BaseDetail
    {
        public BronzeSleeveShutter() : base()
        {
            Name = "Втулка бронзовая";
        }

        public int? ShutterReverseId { get; set; }
        public ShutterReverse ShutterReverse { get; set; }

        public IEnumerable<BronzeSleeveShutterJournal> BronzeSleeveShutterJournals { get; set; }
        [NotMapped]
        public IEnumerable<BronzeSleeveShutterTCP> BronzeSleeveShutterTCPs { get; set; }        
    }
}
