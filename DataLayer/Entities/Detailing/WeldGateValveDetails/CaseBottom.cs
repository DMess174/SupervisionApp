using System.Collections.Generic;
using DataLayer.Journals.Detailing.WeldGateValveDetails;

namespace DataLayer.Entities.Detailing.WeldGateValveDetails
{
    public class CaseBottom : BaseDetail
    {
        public CaseBottom()
        {
            Name = "Днище корпуса";
        }

        public IEnumerable<CaseBottomJournal> CaseBottomJournals { get; set; }
    }
}
