using DataLayer.Journals.Materials.AnticorrosiveCoating;
using System.Collections.Generic;

namespace DataLayer.Entities.Materials.AnticorrosiveCoating
{
    public class AbrasiveMaterial : BaseAnticorrosiveCoating
    {
        public IEnumerable<AbrasiveMaterialJournal> AbrasiveMaterialJournals { get; set; }
    }
}
