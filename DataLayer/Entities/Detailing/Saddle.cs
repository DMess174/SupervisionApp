using DataLayer.Entities.AssemblyUnits;
using DataLayer.Journals.Detailing;
using System.Collections.Generic;

namespace DataLayer.Entities.Detailing
{
    public class Saddle : BaseDetail
    {
        public Saddle()
        {
            Name = "Седло";
        }

        public int? BaseValveId{ get; set; }
        public BaseValve BaseValve { get; set; }

        public IEnumerable<SaddleWithSealing> SaddleWithSealings { get; set; }

        public IEnumerable<SaddleJournal> SaddleJournals { get; set; }
    }
}
