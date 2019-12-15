using DataLayer.Journals.Materials;
using System.Collections.Generic;

namespace DataLayer.Entities.Materials
{
    public class SheetMaterial : MetalMaterial
    {
        public SheetMaterial()
        {
            Name = "Лист";
        }

        public IEnumerable<SheetMaterialJournal> SheetMaterialJournals { get; set; }
    }
}
