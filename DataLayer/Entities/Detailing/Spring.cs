using System.Collections.Generic;
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

        public string Batch { get; set; }

        public int Amount { get; set; }

        public int AmountUsed { get; set; }

        public IEnumerable<BaseValveWithSpring> BaseValveWithSprings { get; set; }

        public IEnumerable<SpringJournal> SpringJournals { get; set; }
    }
}
