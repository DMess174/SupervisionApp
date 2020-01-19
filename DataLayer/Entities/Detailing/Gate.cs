﻿using DataLayer.Entities.AssemblyUnits;
using DataLayer.Entities.Materials;
using DataLayer.Journals.Detailing;
using System.Collections.Generic;

namespace DataLayer.Entities.Detailing
{
    public class Gate : BaseEntity
    {
        public Gate()
        {
            Name = "Шибер";
        }

        public int? MetalMaterialId { get; set; }
        public MetalMaterial MetalMaterial { get; set; }

        public int? PIDId { get; set; }
        public PID PID { get; set; }
        public BaseValve BaseValve { get; set; }

        public IEnumerable<GateJournal> GateJournals { get; set; }
    }
}
