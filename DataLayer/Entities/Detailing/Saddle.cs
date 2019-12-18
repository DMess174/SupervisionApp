using DataLayer.Entities.AssemblyUnits;
using DataLayer.Entities.Materials;
using DataLayer.Journals.Detailing;
using System.Collections.Generic;

namespace DataLayer.Entities.Detailing
{
    public class Saddle : BaseEntity
    {
        public Saddle()
        {
            Name = "Седло";
        }

        public int? MetalMaterialId { get; set; }
        public MetalMaterial MetalMaterial { get; set; }

        public int? BaseValveId{ get; set; }
        public BaseValve BaseValve { get; set; }

        public IEnumerable<SaddleWithSealing> SaddleWithSealings { get; set; }

        public IEnumerable<SaddleJournal> SaddleJournals { get; set; }
    }
}
