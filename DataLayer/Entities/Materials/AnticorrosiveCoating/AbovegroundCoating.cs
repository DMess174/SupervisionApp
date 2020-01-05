using DataLayer.Journals.Materials.AnticorrosiveCoating;
using System.Collections.Generic;

namespace DataLayer.Entities.Materials.AnticorrosiveCoating
{
    public class AbovegroundCoating : BaseAnticorrosiveCoating
    {
        public string Color { get; set; }

        public IEnumerable<AbovegroundCoatingJournal> AbovegroundCoatingJournals { get; set; }
    }
}
