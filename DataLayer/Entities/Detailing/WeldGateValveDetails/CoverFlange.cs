using System.Collections.Generic;
using DataLayer.Journals.Detailing.WeldGateValveDetails;

namespace DataLayer.Entities.Detailing.WeldGateValveDetails
{
    public class CoverFlange : BaseDetail
    {
        public CoverFlange ()
        {
            Name = "Фланец крышки";
        }

        public IEnumerable<CoverFlangeJournal> CoverFlangeJournals { get; set; }
    }
}
