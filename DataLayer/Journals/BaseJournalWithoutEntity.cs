using DataLayer.Entities;
using DataLayer.TechnicalControlPlans;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Journals
{
    public class BaseJournal<TEntityTCP> : BaseTable
        where TEntityTCP : BaseTCP
    {
        public string Point { get; set; }
        public string Description { get; set; }
        public string JournalNumber { get; set; }
        public DateTime? Date { get; set; }
        public string Status { get; set; }
        public string RemarkIssued { get; set; }
        public string RemarkClosed { get; set; }
        public string Comment { get; set; }

        public int? InspectorId { get; set; }
        public Inspector Inspector { get; set; }

        public int? PointId { get; set; }
        [ForeignKey("PointId")]
        public TEntityTCP EntityTCP { get; set; }

        public BaseJournal()
        {
        }

        public BaseJournal(TEntityTCP tCP)
        {
            PointId = tCP.Id;
            Point = tCP.Point;
            Description = tCP.Description;
        }
    }
}
