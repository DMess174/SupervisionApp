using DataLayer.Entities;
using DataLayer.Entities.AssemblyUnits;
using DataLayer.Entities.Detailing;
using DataLayer.TechnicalControlPlans;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataLayer.Journals
{
    public class BaseJournal<TEntity, TEntityTCP> : BasePropertyChanged
        where TEntity : BaseEntity
        where TEntityTCP : BaseTCP
    {
        public int Id { get; set; }
        public string DetailName { get; set; }
        public string DetailNumber { get; set; }
        public string Point { get; set; }
        public string Description { get; set; }
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
