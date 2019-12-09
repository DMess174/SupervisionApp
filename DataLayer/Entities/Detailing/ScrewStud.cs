using System.Collections.Generic;
using DataLayer.Entities.AssemblyUnits;
using DataLayer.Journals.Detailing;

namespace DataLayer.Entities.Detailing
{
    public class ScrewStud : Fasteners
    {
        public ScrewStud()
        {
            Name = "Шпилька";
        }

        public IEnumerable<BaseValveWithScrewStud> BaseValveWithScrewStuds { get; set; }

        public  IEnumerable<ScrewStudJournal> ScrewStudJournals { get; set; }
    }
}
