using System.ComponentModel.DataAnnotations.Schema;
using DataLayer.Entities.Detailing;
using DataLayer.Journals.Detailing;
using System.Collections.Generic;
using DataLayer.TechnicalControlPlans.AssemblyUnits;

namespace DataLayer.Entities.AssemblyUnits
{
    public class CastingValve : BaseShutterValve
    {
        public CastingValve() : base()
        {
            Name = "Задвижка шиберная";
        }

        public int? ValveCaseId { get; set; }
        public ValveCase ValveCase { get; set; }

        public IEnumerable<ShutterReverseJournal> ShutterReverseJournals{ get; set; }
        [NotMapped]
        public IEnumerable<ShutterReverseTCP> ShutterReverseTCPs{ get; set; }
    }
}
