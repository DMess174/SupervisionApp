using DataLayer.Entities;
using DataLayer.TechnicalControlPlans;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Journals
{
    public class BaseJournal<TEntity, TEntityTCP> : BasePropertyChanged
        where TEntity : BaseEntity
        where TEntityTCP : BaseTCP
    {
        //public BaseJournal(TEntity item, BaseJournal<TEntity, TEntityTCP> record)
        //{
        //    DetailName = item.Name;
        //    DetailNumber = item.Number;
        //    Point = record.Point;
        //    Description = record.Description;
        //    Date = record.Date;
        //    Status = record.Status;
        //    Remark = record.Remark;
        //    InspectorId = record.InspectorId;
        //    DetailId = item.Id;
        //    PointId = record.PointId;
        //}

        public int Id { get; set; }
        public string DetailName { get; set; }
        public string DetailNumber { get; set; }
        public string DetailDrawing { get; set; }
        public string Point { get; set; }
        public string Description { get; set; }
        public string JournalNumber { get; set; }
        public DateTime? Date { get; set; }
        public string Status { get; set; }
        public string Remark { get; set; }
        public int? InspectorId { get; set; }
        public int? DetailId{ get; set; }
        public int? PointId { get; set; }

        [ForeignKey("DetailId")]
        public TEntity Entity { get; set; }

        [ForeignKey("PointId")]
        public TEntityTCP EntityTCP { get; set; }
    }
}
