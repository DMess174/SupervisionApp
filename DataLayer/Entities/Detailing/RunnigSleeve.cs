using DataLayer.Files;
using DataLayer.Journals.Detailing;
using System.Collections.ObjectModel;

namespace DataLayer.Entities.Detailing
{
    public class RunningSleeve : BaseDetail
    {
        public RunningSleeve()
        {
            Name = "Втулка ходовая";
        }

        public RunningSleeve(RunningSleeve sleeve) : base(sleeve)
        {
        }

        public BaseValveCover BaseValveCover { get; set; }

        public ObservableCollection<RunningSleeveJournal> RunningSleeveJournals { get; set; }
        public ObservableCollection<RunningSleeveWithFile> Files { get; set; }
    }
}
