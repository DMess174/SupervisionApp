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

        public int? ShutterReverseId { get; set; }
        public ShutterReverse ShutterReverse { get; set; }

        public IEnumerable<SteelSleeveShutterJournal> SteelSleeveShutterJournals{ get; set; }
        [NotMapped]
        public IEnumerable<SteelSleeveShutterTCP> SteelSleeveShutterTCPs{ get; set; }

    }
}
