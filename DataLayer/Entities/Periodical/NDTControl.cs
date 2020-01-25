using DataLayer.Journals.Periodical;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities.Periodical
{
    public class NDTControl : PeriodicalControl
    {
        public IEnumerable<NDTControlJournal> NDTControlJournals { get; set; }
    }
}
