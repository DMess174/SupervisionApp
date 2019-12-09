using DataLayer.Journals.Detailing;
using System.Collections.Generic;

namespace DataLayer.Entities.Detailing
{
    public class Spindle : BaseDetail
    {
        public Spindle()
        {
            Name = "Шпиндель";
        }

        public BaseValveCover BaseValveCover { get; set; }

        public IEnumerable<SpindleJournal> SpindleJournals { get; set; }
    }
}
