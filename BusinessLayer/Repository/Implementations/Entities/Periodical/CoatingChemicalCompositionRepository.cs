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
    public class CoatingChemicalCompositionRepository : Repository<CoatingChemicalCompositionJournal>
    {
        public CoatingChemicalCompositionRepository(DataContext context) : base(context) { }

        public override async Task<IList<CoatingChemicalCompositionJournal>> GetAllAsync()
        {
            await db.CoatingChemicalCompositionJournals.OrderByDescending(x => x.Date).LoadAsync();
            return db.CoatingChemicalCompositionJournals.Local.ToObservableCollection();
        }

        public async Task<IList<CoatingChemicalCompositionTCP>> GetTCPsAsync()
        {
            await db.CoatingChemicalCompositionTCPs.LoadAsync();
            return db.CoatingChemicalCompositionTCPs.Local.ToObservableCollection();
        }

        public DateTime GetLastDateControl()
        {
            return Convert.ToDateTime(db.CoatingChemicalCompositionJournals.Select(i => i.Date).Max());
        }

        public DateTime GetNextDateControl(DateTime date)
        {
            return date.AddDays(7);
        }
    }
}
