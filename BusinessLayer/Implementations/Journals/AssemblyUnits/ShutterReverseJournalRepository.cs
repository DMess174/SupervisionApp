using BusinessLayer.Interfaces.Journals.AssemblyUnits;
using DataLayer;
using DataLayer.Journals.Detailing;

namespace BusinessLayer.Implementations.Journals.AssemblyUnits
{
    public class ShutterReverseJournalRepository : Repository<ShutterReverseJournal>, IShutterReverseJournalRepository
    {
        public ShutterReverseJournalRepository(DataContext context)
            : base(context)
        {
        }

        public DataContext DataContext
        {
            get { return Context as DataContext; }
        }
    }
}
