﻿using DataLayer.Entities.Materials;
using DataLayer.Journals.Detailing;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Entities.Detailing
{
    public class Nozzle : BaseEntity
    {
        public Nozzle()
        {
            Name = "Катушка";
        }

        public string Diameter { get; set; }
        public string Thickness { get; set; }
        public string ThicknessJoin { get; set; }

        public int? MetalMaterialId { get; set; }
        public MetalMaterial MetalMaterial { get; set; }

        public int? CastingCaseId { get; set; }
        public BaseCastingCase CastingCase { get; set; }

        public IEnumerable<NozzleJournal> NozzleJournals { get; set; }

        [NotMapped]
        public new string FullName => string.Format($"{Name}/{Number}/{Diameter}/{Thickness}");
    }
}
