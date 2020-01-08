using DataLayer.Journals;
using System.Collections.Generic;

namespace DataLayer.TechnicalControlPlans
{
    public class PIDTCP : BaseTCP
    {
        public IEnumerable<PIDJournal> PIDJournals { get; set; }
    }
}
