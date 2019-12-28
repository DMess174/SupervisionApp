using DataLayer.Journals.Detailing;
using System.Collections.Generic;

namespace DataLayer.Entities.Detailing
{
    public class Spindle : ValveCoverAssemblyDetail
    {
        public Spindle()
        {
            Name = "Шпиндель";
        }

        public IEnumerable<SpindleJournal> SpindleJournals { get; set; }
    }
}
