using DataLayer.Journals;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.Repository.Interfaces.Entities
{
    public interface IJournalNumberRepository : IRepository<JournalNumber>
    {
        Task<IEnumerable<string>> GetActiveJournalNumbersAsync();
    }
}
