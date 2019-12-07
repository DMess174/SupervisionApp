using BusinessLayer.Interfaces.Journals.Detailing;
using DataLayer;
using DataLayer.Journals.Detailing.ReverseShutterDetails;

namespace BusinessLayer.Implementations.Journals.Detailing
{
    public class CaseShutterJournalRepository : Repository<ReverseShutterCaseJournal>, ICaseShutterJournalRepository
    {
        public CaseShutterJournalRepository(DataContext context)
            : base(context)
        {
        }

        public DataContext DataContext => Context as DataContext;
    }
}
