using BusinessLayer.Repository.Interfaces.Entities;
using DataLayer;
using DataLayer.Journals;
using DataLayer.TechnicalControlPlans;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLayer.Repository.Implementations.Entities
{
    public class FactoryInspectionRepository : Repository<FactoryInspectionJournal>, IFactoryInspectionRepository
    {
        public FactoryInspectionRepository(DataContext context) : base(context) { }

        public override async Task<IList<FactoryInspectionJournal>> GetAllAsync()
        {
            await db.FactoryInspectionJournals.OrderByDescending(x => x.Date).LoadAsync();
            return db.FactoryInspectionJournals.Local.ToObservableCollection();
        }

        public async Task<IList<FactoryInspectionTCP>> GetTCPsAsync()
        {
            await db.FactoryInspectionTCPs.LoadAsync();
            return db.FactoryInspectionTCPs.Local.ToObservableCollection();
        }
    }
}
