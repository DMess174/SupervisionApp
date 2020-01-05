using System.Collections.Generic;
using DataLayer.Entities.AssemblyUnits;
using DataLayer.Journals.Detailing;

namespace DataLayer.Entities.Detailing
{
    public class AssemblyUnitSealing : BaseSealing
    {
        public IEnumerable<BaseValveWithSealing> BaseValveWithSeals { get; set; }

        public IEnumerable<AssemblyUnitSealingJournal> AssemblyUnitSealingJournals { get; set; }
    }
}
