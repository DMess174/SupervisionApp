using DataLayer.Journals.Detailing;
using System.Collections.Generic;

namespace DataLayer.TechnicalControlPlans.Detailing
{
    public class ShearPinTCP : BaseTCP
    {
        public IEnumerable<ShearPinJournal> ShearPinJournals { get; set; }
    }
}
