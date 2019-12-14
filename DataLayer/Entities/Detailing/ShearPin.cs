using DataLayer.Journals.Detailing;
using System.Collections.Generic;
using DataLayer.Entities.AssemblyUnits;

namespace DataLayer.Entities.Detailing
{
    public class ShearPin : BaseDetail
    {
        public ShearPin()
        {
            Name = "Штифт срезной";
        }

        public int? BaseValveId { get; set; }
        public BaseValve BaseValve { get; set; }

        public IEnumerable<ShearPinJournal> ShearPinJournals { get; set; }
    }
}
