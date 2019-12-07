using BusinessLayer.Interfaces.Journals.AssemblyUnits;
using DataLayer;
using DataLayer.Journals.AssemblyUnits;

namespace BusinessLayer.Implementations.Journals.AssemblyUnits
{
    public class ShutterReverseJournalRepository : Repository<ReverseShutterJournal>, IShutterReverseJournalRepository
    {
        public ShutterReverseJournalRepository(DataContext context)
            : base(context)
        {
        }

        public DataContext DataContext => Context as DataContext;
    }
}
