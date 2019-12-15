using DataLayer.Journals.Materials;
using System.Collections.Generic;

namespace DataLayer.Entities.Materials
{
    public class PipeMaterial : MetalMaterial
    {
        public PipeMaterial()
        {
            Name = "Труба";
        }

        public IEnumerable<PipeMaterialJournal> PipeMaterialJournals { get; set; }
    }
}
