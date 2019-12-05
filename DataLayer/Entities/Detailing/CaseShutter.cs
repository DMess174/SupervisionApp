using DataLayer.Entities.AssemblyUnits;
using DataLayer.Journals.Detailing;
using DataLayer.TechnicalControlPlans.Detailing;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Entities.Detailing
{
    public class ShutterCase : BaseCastingCase
    {
        public ShutterCase() : base()
        {
            Name = "Корпус затвора";
        }

        public List<ShutterReverse> ShutterReverses { get; set; }

        public List<CaseShutterJournal> CaseShutterJournals{ get; set; }
        [NotMapped]
        public List<CaseShutterTCP> CaseShutterTCPs{ get; set; }
    }
}
