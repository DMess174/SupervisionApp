using DataLayer.TechnicalControlPlans.Detailing;
using Supervision.ViewModels.DTO.Entities.Detailing;
using Supervision.ViewModels.DTO.Journals.Detailing;
using System.Collections.Generic;

namespace Supervision.ViewModels.DTO.TechnicalControlPlans.Detailing
{
    public class BronzeSleeveShutterTCPDTO : BaseTCPDTO
    {
        public BronzeSleeveShutterTCPDTO() : base()
        {
        }

        public BronzeSleeveShutterTCPDTO(BronzeSleeveShutterTCP item) : base()
        {
        }

        public List<BronzeSleeveShutterJournalDTO> BronzeSleeveShutterJournals { get; set; }

        public List<BronzeSleeveShutterDTO> BronzeSleeveShutters { get; set; }
    }
}
