using DataLayer.Journals.Materials.AnticorrosiveCoating;
using System.Collections.Generic;

namespace DataLayer.Entities.Materials.AnticorrosiveCoating
{
    public class UndergroundCoating : BaseAnticorrosiveCoating
    {
        public IEnumerable<UndergroundCoatingJournal> UndergroundCoatingJournals { get; set; }
    }

    
}
