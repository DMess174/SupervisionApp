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

        public ShutterReverse ShutterReverse { get; set; }

        public IEnumerable<ShaftShutterJournal> ShaftShutterJournals { get; set; }
        [NotMapped]
        public IEnumerable<ShaftShutterTCP> ShaftShutterTCPs { get; set; }
    }
}
