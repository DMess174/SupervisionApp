using DataLayer.Journals.Materials.AnticorrosiveCoating;
using System.Collections.Generic;

namespace DataLayer.Entities.Materials.AnticorrosiveCoating
{
    public class AbovegroundCoating : BaseAnticorrosiveCoating
    {
        public string Color { get; set; }

        public new string FullName => string.Format($"{Batch}/{Name} - {Color}/{Status}");

        public IEnumerable<AbovegroundCoatingJournal> AbovegroundCoatingJournals { get; set; }
    }
}
