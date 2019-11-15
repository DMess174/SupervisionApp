using DataLayer.Entities.AssemblyUnits;
using DataLayer.Journals.Detailing;
using DataLayer.TechnicalControlPlans.Detailing;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Entities.Detailing
{
    public class SteelSleeveShutter : BaseDetail
    {
        public SteelSleeveShutter() : base()
        {
            Name = "Втулка стальная";
        }

        public List<ShutterReverse> FirstShutterReverses { get; set; }
        public List<ShutterReverse> SecondShutterReverses { get; set; }

        public List<SteelSleeveShutterJournal> SteelSleeveShutterJournals{ get; set; }
        [NotMapped]
        public List<SteelSleeveShutterTCP> SteelSleeveShutterTCPs{ get; set; }

    }
}
