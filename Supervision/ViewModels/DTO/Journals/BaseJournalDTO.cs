using DataLayer;
using DataLayer.Journals;
using System;

namespace Supervision.ViewModels.DTO.Journals
{
    public class BaseJournalDTO : BasePropertyChanged
    {
        public BaseJournalDTO()
        {
        }

        public BaseJournalDTO(BaseJournal item)
        {
            Id = item.Id;
            Date = item.Date;
            Status = item.Status;
            InspectorId = item.InspectorId;
        }

        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public string Status { get; set; }
        public string Remark { get; set; }
        public int? InspectorId { get; set; }
    }
}
