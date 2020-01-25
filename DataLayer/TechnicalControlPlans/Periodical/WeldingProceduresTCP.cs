using DataLayer.Journals.Periodical;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.TechnicalControlPlans.Periodical
{
    public class WeldingProceduresTCP : BaseTCP
    {
        public IEnumerable<WeldingProceduresJournal> WeldingProceduresJournals { get; set; }
    }
}
