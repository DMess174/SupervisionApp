using DataLayer.Journals.Detailing;
using System.Collections.Generic;

namespace DataLayer.Entities.Detailing
{
    public class RunningSleeve : BaseDetail
    {
        public RunningSleeve()
        {
            Name = "Втулка ходовая";
        }

        public BaseValveCover BaseValveCover { get; set; }

        public IEnumerable<RunningSleeveJournal> RunningSleeveJournals { get; set; }
    }
}
