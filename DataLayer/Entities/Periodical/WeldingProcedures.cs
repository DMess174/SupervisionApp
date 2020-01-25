using DataLayer.Journals.Periodical;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities.Periodical
{
    public class WeldingProcedures : PeriodicalControl
    {
        public IEnumerable<WeldingProceduresJournal> WeldingProceduresJournals { get; set; }
    }
}
