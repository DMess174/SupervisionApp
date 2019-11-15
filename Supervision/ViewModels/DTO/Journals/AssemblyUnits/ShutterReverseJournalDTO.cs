using DataLayer.Journals.Detailing;

namespace Supervision.ViewModels.DTO.Journals.AssemblyUnits
{
    public class ShutterReverseJournalDTO : BaseJournalDTO
    {
        public ShutterReverseJournalDTO(ShutterReverseJournal item) 
            : base()
        {
            ShutterReverseId = item.ShutterReverseId;
            ShutterReverseTCPId = item.ShutterReverseTCPId;
        }
        public int? ShutterReverseId { get; set; }
        public int? ShutterReverseTCPId { get; set; }
    }
}
