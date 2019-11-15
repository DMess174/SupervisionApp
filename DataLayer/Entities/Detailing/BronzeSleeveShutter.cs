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

        public List<ShutterReverse> FirstShutterReverses { get; set; }
        public List<ShutterReverse> SecondShutterReverses { get; set; }

        public List<BronzeSleeveShutterJournal> BronzeSleeveShutterJournals { get; set; }
        [NotMapped]
        public List<BronzeSleeveShutterTCP> BronzeSleeveShutterTCPs { get; set; }        
    }
}
