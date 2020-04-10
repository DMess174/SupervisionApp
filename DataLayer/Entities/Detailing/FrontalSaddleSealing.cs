using System.Collections.ObjectModel;
using DataLayer.Journals.Detailing;

namespace DataLayer.Entities.Detailing
{
    public class FrontalSaddleSealing : BaseSealing
    {
        public FrontalSaddleSealing()
        {
            Name = "Уплотнитель седла торцевой";
        }

        public FrontalSaddleSealing(FrontalSaddleSealing sealing) : base(sealing)
        {
        }

        public ObservableCollection<SaddleWithSealing> SaddleWithSealings { get; set; }

        public ObservableCollection<FrontalSaddleSealingJournal> FrontalSaddleSealingJournals { get; set; }
    }
}
