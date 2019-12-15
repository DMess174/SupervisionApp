using DataLayer.Journals.Materials;
using System.Collections.Generic;

namespace DataLayer.Entities.Materials
{
    public class RolledMaterial : MetalMaterial
    {
        public RolledMaterial()
        {
            Name = "Прокат";
        }

        public IEnumerable<RolledMaterialJournal> RolledMaterialJournals { get; set; }
    }
}
