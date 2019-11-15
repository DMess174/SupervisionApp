using DataLayer.Entities.Detailing;
using Supervision.ViewModels.DTO.Entities.AssemblyUnits;
using Supervision.ViewModels.DTO.Journals.Detailing;
using Supervision.ViewModels.DTO.TechnicalControlPlans.Detailing;
using System.Collections.Generic;

namespace Supervision.ViewModels.DTO.Entities.Detailing
{
    public class BronzeSleeveShutterDTO : BaseDetailDTO
    {
        public BronzeSleeveShutterDTO(BronzeSleeveShutter item) : base()
        {
        }

        public List<ShutterReverseDTO> FirstShutterReverses { get; set; }
        public List<ShutterReverseDTO> SecondShutterReverses { get; set; }

        public List<BronzeSleeveShutterJournalDTO> BronzeSleeveShutterJournals { get; set; }
        public List<BronzeSleeveShutterTCPDTO> BronzeSleeveShutterTCPs { get; set; }        
    }
}
