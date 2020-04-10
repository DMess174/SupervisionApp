using DataLayer.Journals.Materials.AnticorrosiveCoating;
using System.Collections.ObjectModel;

namespace DataLayer.Entities.Materials.AnticorrosiveCoating
{
    public class AbovegroundCoating : BaseAnticorrosiveCoating
    {
        public string Color { get; set; }

        public new string FullName => string.Format($"{Batch}/{Name} - {Color}/{Status}");

        public ObservableCollection<AbovegroundCoatingJournal> AbovegroundCoatingJournals { get; set; }

        public AbovegroundCoating()
        {
        }

        public AbovegroundCoating(AbovegroundCoating coating) : base(coating)
        {
            Color = coating.Color;
        }
    }
}
