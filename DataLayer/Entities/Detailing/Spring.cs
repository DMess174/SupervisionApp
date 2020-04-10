using System.Collections.ObjectModel;
using DataLayer.Entities.AssemblyUnits;
using DataLayer.Journals.Detailing;

namespace DataLayer.Entities.Detailing
{
    public class Spring : BaseDetail
    {
        public Spring()
        {
            Name = "Пружина";
        }

        public Spring(Spring spring) : base(spring)
        {
        }

        public string Batch { get; set; }

        public int Amount { get; set; }

        public int? AmountRemaining { get; set; }

        public ObservableCollection<BaseValveWithSpring> BaseValveWithSprings { get; set; }

        public ObservableCollection<SpringJournal> SpringJournals { get; set; }
    }
}