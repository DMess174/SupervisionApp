using System.Collections.Generic;
using DataLayer.Journals.Detailing;

namespace DataLayer.Entities.Detailing
{
    public class FrontalSaddleSealing : BaseSealing
    {
        public FrontalSaddleSealing()
        {
            Name = "Уплотнитель седла торцевой";
        }
        public IEnumerable<SaddleWithSealing> SaddleWithSealings { get; set; }

        public IEnumerable<FrontalSaddleSealingJournal> FrontalSaddleSealingJournals { get; set; }
    }
}
