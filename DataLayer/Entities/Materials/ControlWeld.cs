using DataLayer.Journals.Materials;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Entities.Materials
{
    public class ControlWeld : BaseTable
    {
        public string Number { get; set; }
        public string MechanicalPropertiesReport { get; set; }
        public string MetallographicPropertiesReport { get; set; }
        public DateTime? BeginingDate { get; set; }
        public DateTime? ExpiryDate { get; set; }

        [NotMapped] 
        //public string FullName => string.Format($"{Batch}/{Name}");

        public IEnumerable<ControlWeldJournal> ControlWeldJournals { get; set; }
    }
}
