using DataLayer.Journals.Materials;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Entities.Materials
{
    public class ControlWeld : BaseTable
    {
        public string Name { get; set; } = "КСС";
        public string Number { get; set; }
        public string MechanicalPropertiesReport { get; set; }
        public string MetallographicPropertiesReport { get; set; }
        public string WeldingMethod { get; set; }
        public string Welder { get; set; }
        public string Stamp { get; set; }
        public string FirstMaterial { get; set; }
        public string SecondMaterial { get; set; }
        public string Size { get; set; }
        public string Status { get; set; }
        public DateTime? BeginingDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string Comment { get; set; }

        [NotMapped] 
        public string FullName => string.Format($"{Name} № {Number}/{WeldingMethod}/ до {ExpiryDate}");

        public IEnumerable<ControlWeldJournal> ControlWeldJournals { get; set; }
    }
}
