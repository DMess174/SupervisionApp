using BusinessLayer.Interfaces.Journals.Detailing;
using DataLayer;
using DataLayer.Journals.Detailing;

namespace BusinessLayer.Implementations.Journals.Detailing
{
    public class SteelSleeveShutterJournalRepository : Repository<SteelSleeveShutterJournal>, ISteelSleeveShutterJournalRepository
    {
        public SteelSleeveShutterJournalRepository(DataContext context)
            : base(context)
        {
        }

        public DataContext DataContext
        {
            get { return Context as DataContext; }
        }
    }
}
