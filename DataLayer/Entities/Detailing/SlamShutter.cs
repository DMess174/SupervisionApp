using DataLayer.Entities.AssemblyUnits;
using DataLayer.Journals.Detailing;
using DataLayer.TechnicalControlPlans.Detailing;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Entities.Detailing
{
    public class SlamShutter : BaseDetail
    {
        public SlamShutter() : base()
        {
            Name = "Захлопка";
        }

        public List<ShutterReverse> ShutterReverses { get; set; }

        public List<SlamShutterJournal> SlamShutterJournals{ get; set; }
        [NotMapped]
        public List<SlamShutterTCP> SlamShutterTCPs{ get; set; }
    }
}

