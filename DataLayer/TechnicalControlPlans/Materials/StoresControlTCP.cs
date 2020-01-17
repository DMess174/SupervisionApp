using DataLayer.Journals.Materials;
using System.Collections.Generic;

namespace DataLayer.TechnicalControlPlans.Materials
{
    public class StoresControlTCP : BaseTCP
    {
        public IEnumerable<StoresControlJournal> StoresControlJournals { get; set; }
    }
}
