using BusinessLayer.Repository.Interfaces.Entities;
using DataLayer;
using DataLayer.Journals;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLayer.Repository.Implementations.Entities
{
    public class JournalNumberRepository : Repository<JournalNumber>, IJournalNumberRepository
    {
        public JournalNumberRepository(DataContext context) : base(context)
        { }

        public async Task<IEnumerable<string>> GetActiveJournalNumbersAsync()
        {
            return await db.JournalNumbers.Where(i => i.IsClosed == false).Select(i => i.Number).Distinct().ToListAsync();
        }
    }
}
