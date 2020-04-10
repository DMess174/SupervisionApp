using BusinessLayer.Repository.Interfaces.Entities;
using DataLayer;
using DataLayer.Journals.Materials;
using DataLayer.TechnicalControlPlans.Materials;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLayer.Repository.Implementations.Entities
{
    public class StoreControlRepository : Repository<StoresControlJournal>, IStoreControlRepository
    {
        public StoreControlRepository(DataContext context) : base(context) { }

        public override async Task<IList<StoresControlJournal>> GetAllAsync()
        {
            await db.StoresControlJournals.OrderByDescending(x => x.Date).LoadAsync();
            return db.StoresControlJournals.Local.ToObservableCollection();
        }

        public async Task<IList<StoresControlTCP>> GetTCPsAsync()
        {
            await db.StoresControlTCPs.LoadAsync();
            return db.StoresControlTCPs.Local.ToObservableCollection();
        }

        public DateTime GetLastDateControl()
        {
            return Convert.ToDateTime(db.StoresControlJournals.Select(i => i.Date).Max());
        }
    }
}
