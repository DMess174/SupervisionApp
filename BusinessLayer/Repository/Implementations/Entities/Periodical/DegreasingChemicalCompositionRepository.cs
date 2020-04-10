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
    public class DegreasingChemicalCompositionRepository : Repository<DegreasingChemicalCompositionJournal>
    {
        public DegreasingChemicalCompositionRepository(DataContext context) : base(context) { }

        public override async Task<IList<DegreasingChemicalCompositionJournal>> GetAllAsync()
        {
            await db.DegreasingChemicalCompositionJournals.OrderByDescending(x => x.Date).LoadAsync();
            return db.DegreasingChemicalCompositionJournals.Local.ToObservableCollection();
        }

        public async Task<IList<DegreasingChemicalCompositionTCP>> GetTCPsAsync()
        {
            await db.DegreasingChemicalCompositionTCPs.LoadAsync();
            return db.DegreasingChemicalCompositionTCPs.Local.ToObservableCollection();
        }

        public DateTime GetLastDateControl()
        {
            return Convert.ToDateTime(db.DegreasingChemicalCompositionJournals.Select(i => i.Date).Max());
        }

        public DateTime GetNextDateControl(DateTime date)
        {
            return date.AddMonths(1);
        }
    }
}
