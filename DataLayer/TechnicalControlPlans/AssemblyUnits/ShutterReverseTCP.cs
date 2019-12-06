using DataLayer.Entities.AssemblyUnits;
using DataLayer.Journals.Detailing;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.TechnicalControlPlans.AssemblyUnits
{
    public class ShutterReverseTCP: BaseTCP
    {
        public IEnumerable<ShutterReverseJournal> ShutterReverseJournals { get; set; }

        [NotMapped]
        public IEnumerable<ShutterReverse> ShutterReverses { get; set; }
    }
}
