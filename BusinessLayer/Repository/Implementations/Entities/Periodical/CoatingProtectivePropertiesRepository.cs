using DataLayer;
using DataLayer.Journals.Periodical;
using DataLayer.TechnicalControlPlans.Periodical;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLayer.Repository.Implementations.Entities
{
    public class CoatingProtectivePropertiesRepository : Repository<CoatingProtectivePropertiesJournal>
    {
        public CoatingProtectivePropertiesRepository(DataContext context) : base(context) { }

        public override async Task<IList<CoatingProtectivePropertiesJournal>> GetAllAsync()
        {
            await db.CoatingProtectivePropertiesJournals.OrderByDescending(x => x.Date).LoadAsync();
            return db.CoatingProtectivePropertiesJournals.Local.ToObservableCollection();
        }

        public async Task<IList<CoatingProtectivePropertiesTCP>> GetTCPsAsync()
        {
            await db.CoatingProtectivePropertiesTCPs.LoadAsync();
            return db.CoatingProtectivePropertiesTCPs.Local.ToObservableCollection();
        }

        public DateTime GetLastDateControl()
        {
            return Convert.ToDateTime(db.CoatingProtectivePropertiesJournals.Select(i => i.Date).Max());
        }

        public DateTime GetNextDateControl(DateTime date)
        {
            return date.AddYears(3);
        }
    }
}
