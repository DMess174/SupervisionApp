using DataLayer.Journals.Detailing;
using System.Collections.Generic;

namespace DataLayer.TechnicalControlPlans.Detailing
{
    public class BallValveTCP : BaseTCP
    {
        public IEnumerable<BallValveJournal> BallValveJournals { get; set; }
    }
}
