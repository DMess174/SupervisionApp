using System.ComponentModel.DataAnnotations.Schema;
using DataLayer.Entities.Detailing;
using DataLayer.Journals.Detailing;
using System.Collections.Generic;
using DataLayer.TechnicalControlPlans.AssemblyUnits;

namespace DataLayer.Entities.AssemblyUnits
{
    public class ShutterReverse : BaseAssemblyUnit
    {
        public ShutterReverse() : base()
        {
            Name = "Затвор";
        }

        public int? CaseShutterId { get; set; }
        public int? ShaftShutterId { get; set; }
        public int? SlamShutterId { get; set; }
        public int? FirstBronzeSleeveShutterId { get; set; }
        public int? SecondBronzeSleeveShutterId { get; set; }
        public int? FirstSteelSleeveShutterId { get; set; }
        public int? SecondSteelSleeveShutterId { get; set; }
        public int? FirstStubShutterId { get; set; }
        public int? SecondStubShutterId { get; set; }

        [InverseProperty("FirstShutterReverses")]
        public BronzeSleeveShutter FirstBronzeSleeveShutter { get; set; }

        [InverseProperty("SecondShutterReverses")]
        public BronzeSleeveShutter SecondBronzeSleeveShutter { get; set; }

        [InverseProperty("FirstShutterReverses")]
        public SteelSleeveShutter FirstSteelSleeveShutter { get; set; }

        [InverseProperty("SecondShutterReverses")]
        public SteelSleeveShutter SecondSteelSleeveShutter { get; set; }

        [InverseProperty("FirstShutterReverses")]
        public StubShutter FirstStubShutter { get; set; }

        [InverseProperty("SecondShutterReverses")]
        public StubShutter SecondStubShutter { get; set; }

        public List<ShutterReverseJournal> ShutterReverseJournals{ get; set; }
        [NotMapped]
        public List<ShutterReverseTCP> ShutterReverseTCPs{ get; set; }
    }
}
