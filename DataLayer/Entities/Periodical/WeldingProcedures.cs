using DataLayer.Journals.Periodical;
using System.Collections.ObjectModel;

namespace DataLayer.Entities.Periodical
{
    public class WeldingProcedures : PeriodicalControl
    {
        public ObservableCollection<WeldingProceduresJournal> WeldingProceduresJournals { get; set; }
    }
}
