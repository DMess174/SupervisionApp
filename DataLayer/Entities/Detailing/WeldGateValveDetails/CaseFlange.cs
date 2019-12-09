using System.Collections.Generic;
using DataLayer.Journals.Detailing.WeldGateValveDetails;

namespace DataLayer.Entities.Detailing.WeldGateValveDetails
{
    public class CaseFlange : BaseDetail
    {
        public CaseFlange()
        {
            Name = "Фланец корпуса";
        }

        public IEnumerable<CaseFlangeJournal> CaseFlangeJournals { get; set; }
    }
}
