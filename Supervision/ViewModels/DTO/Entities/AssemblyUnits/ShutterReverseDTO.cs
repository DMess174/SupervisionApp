using DataLayer.Entities.AssemblyUnits;
using Supervision.ViewModels.DTO.Journals.AssemblyUnits;
using Supervision.ViewModels.DTO.TechnicalControlPlans.AssemblyUnits;
using System.Collections.Generic;

namespace Supervision.ViewModels.DTO.Entities.AssemblyUnits
{
    public class ShutterReverseDTO : BaseAssemblyUnitDTO
    {
        public ShutterReverseDTO() : base()
        {
        }

        public ShutterReverseDTO(ShutterReverse item) : base()
        {
            CaseShutterId = item.CaseShutterId;
            ShaftShutterId = item.ShaftShutterId;
            SlamShutterId = item.SlamShutterId;
            FirstBronzeSleeveShutterId = item.FirstBronzeSleeveShutterId;
            SecondBronzeSleeveShutterId = item.SecondBronzeSleeveShutterId;
            FirstSteelSleeveShutterId = item.FirstSteelSleeveShutterId;
            SecondSteelSleeveShutterId = item.SecondSteelSleeveShutterId;
            FirstStubShutterId = item.FirstStubShutterId;
            SecondStubShutterId = item.SecondStubShutterId;
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

        public List<ShutterReverseJournalDTO> ShutterReverseJournals{ get; set; }
       
        public List<ShutterReverseTCPDTO> ShutterReverseTCPs{ get; set; }
    }
}
