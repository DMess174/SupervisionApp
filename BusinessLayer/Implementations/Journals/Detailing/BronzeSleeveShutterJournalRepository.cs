using BusinessLayer.Interfaces.Journals.Detailing;
using DataLayer;
using DataLayer.Journals.Detailing;

namespace BusinessLayer.Implementations.Journals.Detailing
{
    public class BronzeSleeveShutterJournalRepository : Repository<BronzeSleeveShutterJournal>, IBronzeSleeveShutterJournalRepository
    {
        public BronzeSleeveShutterJournalRepository(DataContext context)
            : base(context)
        {
        }

        public DataContext DataContext
        {
            get { return Context as DataContext; }
        }
    }
}
