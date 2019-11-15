using DataLayer.Journals.Detailing;

namespace Supervision.ViewModels.DTO.Journals.Detailing
{
    public class BronzeSleeveShutterJournalDTO : BaseJournalDTO
    {
        public BronzeSleeveShutterJournalDTO() : base()
        {
        }

        public BronzeSleeveShutterJournalDTO(BronzeSleeveShutterJournal item) :base()
        {
            BronzeSleeveShutterId = item.BronzeSleeveShutterId;
            BronzeSleeveShutterTCPId = item.BronzeSleeveShutterTCPId;
        }

        public int? BronzeSleeveShutterId { get; set; }
        public int? BronzeSleeveShutterTCPId { get; set; }
    }
}
