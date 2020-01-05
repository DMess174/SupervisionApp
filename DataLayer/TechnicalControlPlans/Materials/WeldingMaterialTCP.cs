using DataLayer.Journals.Materials;
using System.Collections.Generic;

namespace DataLayer.TechnicalControlPlans.Materials
{
    public class WeldingMaterialTCP : BaseTCP
    {
        public IEnumerable<WeldingMaterialJournal> WeldingMaterialJournals { get; set; }
    }
}
