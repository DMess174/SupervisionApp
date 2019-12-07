using BusinessLayer.Interfaces.Journals.Detailing;
using DataLayer;
using DataLayer.Journals.Detailing.ReverseShutterDetails;

namespace BusinessLayer.Implementations.Journals.Detailing
{
    public class SlamShutterJournalRepository : Repository<SlamShutterJournal>, ISlamShutterJournalRepository
    {
        public SlamShutterJournalRepository(DataContext context)
            : base(context)
        {
        }

        public DataContext DataContext => Context as DataContext;
    }
}
