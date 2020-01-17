using DataLayer.Journals.Materials;
using System.Collections.Generic;

namespace DataLayer.TechnicalControlPlans.Materials
{
    public class ControlWeldTCP : BaseTCP
    {
        public IEnumerable<ControlWeldJournal> ControlWeldJournals { get; set; }
    }
}
