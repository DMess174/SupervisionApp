using DataLayer.Entities.AssemblyUnits;
using DataLayer.Journals.Detailing;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.TechnicalControlPlans.AssemblyUnits
{
    public class ShutterReverseTCP: BaseTCP
    {
        public List<ShutterReverseJournal> ShutterReverseJournals { get; set; }

        [NotMapped]
        public List<ShutterReverse> ShutterReverses { get; set; }
    }
}
