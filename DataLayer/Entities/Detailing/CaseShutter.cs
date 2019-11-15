using DataLayer.Entities.AssemblyUnits;
using DataLayer.Journals.Detailing;
using DataLayer.TechnicalControlPlans.Detailing;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Entities.Detailing
{
    public class CaseShutter : BaseDetail
    {
        public CaseShutter() : base()
        {
            Name = "Корпус затвора";
        }

        public int? FirstNozzleId { get; set; }
        public int? SecondNozzleId { get; set; }

        [InverseProperty("FirstCaseShutters")]
        public Nozzle FirstNozzle { get; set; }

        [InverseProperty("SecondCaseShutters")]
        public Nozzle SecondNozzle { get; set; }

        public List<ShutterReverse> ShutterReverses { get; set; }

        public List<CaseShutterJournal> CaseShutterJournals{ get; set; }
        [NotMapped]
        public List<CaseShutterTCP> CaseShutterTCPs{ get; set; }
    }
}
