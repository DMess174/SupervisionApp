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
    public class CoatingPorosityRepository : Repository<CoatingPorosityJournal>
    {
        public CoatingPorosityRepository(DataContext context) : base(context) { }

        public override async Task<IList<CoatingPorosityJournal>> GetAllAsync()
        {
            await db.CoatingPorosityJournals.OrderByDescending(x => x.Date).LoadAsync();
            return db.CoatingPorosityJournals.Local.ToObservableCollection();
        }

        public async Task<IList<CoatingPorosityTCP>> GetTCPsAsync()
        {
            await db.CoatingPorosityTCPs.LoadAsync();
            return db.CoatingPorosityTCPs.Local.ToObservableCollection();
        }

        public DateTime GetLastDateControl()
        {
            return Convert.ToDateTime(db.CoatingPorosityJournals.Select(i => i.Date).Max());
        }

        /// <summary>
        /// Возвращает дату следующей проверки
        /// </summary>
        /// <param name="date">Дата последней проверки</param>
        /// <returns></returns>
        public DateTime GetNextDateControl(DateTime date)
        {
            return date.AddYears(1);
        }

        /// <summary>
        /// Возвращает количество покрытых шиберов с даты последней проверки
        /// </summary>
        /// <param name="date">Дата последней проверки</param>
        /// <returns></returns>
        public int GetCoutedGatesCount(DateTime date)
        {
            return Convert.ToInt32(db.GateJournals.Where(i => i.Date > date && i.PointId == 385).Select(i => i.DetailId).Distinct().Count());
        }
    }
}
