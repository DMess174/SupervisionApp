using DataLayer.Journals.Materials.AnticorrosiveCoating;
using System.Collections.ObjectModel;

namespace DataLayer.Entities.Materials.AnticorrosiveCoating
{
    public class UndergroundCoating : BaseAnticorrosiveCoating
    {
        public ObservableCollection<UndergroundCoatingJournal> UndergroundCoatingJournals { get; set; }

        public UndergroundCoating()
        {
        }

        public UndergroundCoating(UndergroundCoating coating) : base(coating)
        {

        }
    }
}
