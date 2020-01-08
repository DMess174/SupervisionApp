using DataLayer.Journals.AssemblyUnits;
using System.Collections.Generic;

namespace DataLayer.Entities.AssemblyUnits
{
    public class BaseAssemblyUnit : BaseEntity
    {
        public int? PIDId { get; set; }
        public PID PID { get; set; }

        public IEnumerable<CoatingJournal> CoatingJournals { get; set; }
    }
}
