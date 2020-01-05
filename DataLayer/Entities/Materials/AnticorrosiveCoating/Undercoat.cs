using DataLayer.Journals.Materials.AnticorrosiveCoating;
using System.Collections.Generic;

namespace DataLayer.Entities.Materials.AnticorrosiveCoating
{
    public class Undercoat : BaseAnticorrosiveCoating
    {
        public IEnumerable<UndercoatJournal> UndercoatJournals { get; set; }
    }
}
