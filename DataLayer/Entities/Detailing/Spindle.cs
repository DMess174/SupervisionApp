using DataLayer.Entities.Materials;
using DataLayer.Journals.Detailing;
using System.Collections.Generic;

namespace DataLayer.Entities.Detailing
{
    public class Spindle : BaseEntity
    {
        public Spindle()
        {
            Name = "Шпиндель";
        }

        public int? MetalMaterialId { get; set; }
        public MetalMaterial MetalMaterial { get; set; }

        public BaseValveCover BaseValveCover { get; set; }

        public IEnumerable<SpindleJournal> SpindleJournals { get; set; }
    }
}
