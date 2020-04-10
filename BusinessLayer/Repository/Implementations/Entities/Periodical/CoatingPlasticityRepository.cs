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
    public class CoatingPlasticityRepository : Repository<CoatingPlasticityJournal>
    {
        public CoatingPlasticityRepository(DataContext context) : base(context) { }

        public override async Task<IList<CoatingPlasticityJournal>> GetAllAsync()
        {
            await db.CoatingPlasticityJournals.OrderByDescending(x => x.Date).LoadAsync();
            return db.CoatingPlasticityJournals.Local.ToObservableCollection();
        }

        public async Task<IList<CoatingPlasticityTCP>> GetTCPsAsync()
        {
            await db.CoatingPlasticityTCPs.LoadAsync();
            return db.CoatingPlasticityTCPs.Local.ToObservableCollection();
        }

        public DateTime GetLastDateControl()
        {
            return Convert.ToDateTime(db.CoatingPlasticityJournals.Select(i => i.Date).Max());
        }

        public DateTime GetNextDateControl(DateTime date)
        {
            return date.AddYears(3);
        }
    }
}
