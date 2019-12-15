using DataLayer.Journals.Materials;
using System.Collections.Generic;

namespace DataLayer.Entities.Materials
{
    public class ForgingMaterial : MetalMaterial
    {
        public ForgingMaterial()
        {
            Name = "Поковка";
        }

        public string MetalCharge { get; set; }

        public IEnumerable<ForgingMaterialJournal> ForgingMaterialJournals { get; set; }
    }
}
