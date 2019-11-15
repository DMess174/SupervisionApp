using DataLayer.TechnicalControlPlans.AssemblyUnits;
using Supervision.ViewModels.DTO.Entities.AssemblyUnits;
using Supervision.ViewModels.DTO.Journals.AssemblyUnits;
using System.Collections.Generic;

namespace Supervision.ViewModels.DTO.TechnicalControlPlans.AssemblyUnits
{
    public class ShutterReverseTCPDTO: BaseTCPDTO
    {
        public ShutterReverseTCPDTO() : base()
        {
        }

        public ShutterReverseTCPDTO(ShutterReverseTCP item) : base()
        {
        }

        public List<ShutterReverseJournalDTO> ShutterReverseJournals { get; set; }

        public List<ShutterReverseDTO> ShutterReverses { get; set; }
    }
}
