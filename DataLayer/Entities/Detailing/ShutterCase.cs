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

        public ShutterReverse ShutterReverse { get; set; }

        public IEnumerable<ShutterCaseJournal> ShutterCaseJournals { get; set; }
        [NotMapped]
        public IEnumerable<ShutterCaseTCP> ShutterCaseTCPs { get; set; }
    }
}
