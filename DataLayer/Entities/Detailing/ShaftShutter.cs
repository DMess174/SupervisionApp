using DataLayer.Entities.AssemblyUnits;
using DataLayer.Journals.Detailing;
using DataLayer.TechnicalControlPlans.Detailing;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Entities.Detailing
{
    public class ShaftShutter : BaseDetail
    {
        public ShaftShutter() : base()
        {
            Name = "Ось затвора";
        }

        public List<ShutterReverse> ShutterReverses { get; set; }

        public List<ShaftShutterJournal> ShaftShutterJournals { get; set; }
        [NotMapped]
        public List<ShaftShutterTCP> ShaftShutterTCPs { get; set; }
    }
}
