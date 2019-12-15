using DataLayer.Journals.Materials;
using System.Collections.Generic;

namespace DataLayer.TechnicalControlPlans.Materials
{
    public class MetalMaterialTCP : BaseTCP
    {
        public IEnumerable<SheetMaterialJournal> SheetMaterialJournals { get; set; }
        public IEnumerable<ForgingMaterialJournal> ForgingMaterialJournals { get; set; }
        public IEnumerable<RolledMaterialJournal> RolledMaterialJournals { get; set; }
    }
}
