using DataLayer.Entities.AssemblyUnits;
using DataLayer.Journals.Detailing;
using DataLayer.TechnicalControlPlans.Detailing;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Entities.Detailing
{
    public class StubShutter : BaseDetail
    {
        public StubShutter() : base()
        {
            Name = "Заглушка затвора";
        }

        public List<ShutterReverse> FirstShutterReverses { get; set; }
        public List<ShutterReverse> SecondShutterReverses { get; set; }

        public List<StubShutterJournal> StubShutterJournals { get; set; }
        [NotMapped]
        public List<StubShutterTCP> StubShutterTCPs { get; set; }
    }
}
