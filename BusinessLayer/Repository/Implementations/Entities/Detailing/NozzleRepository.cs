﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Repository.Interfaces.Entities.Detailing;
using DataLayer;
using DataLayer.Entities.Detailing;
using DataLayer.Journals.Detailing;
using DataLayer.TechnicalControlPlans.Detailing;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Repository.Implementations.Entities.Detailing
{
    public class NozzleRepository : Repository<Nozzle, NozzleJournal, NozzleTCP>, INozzleRepository
    {
        public NozzleRepository(DataContext context) : base(context)
        {
            DbEntity = context.Nozzles;
            DbJournal = context.NozzleJournals;
            DbTCP = context.NozzleTCPs;
        }

        public async Task<Nozzle> GetInclude(int id)
        {
            return await DbEntity.Include(i => i.CastingCase).SingleOrDefaultAsync(i => i.Id == id);
        }

        public IEnumerable<NozzleJournal> GetJournal(Nozzle nozzle)
        {
            return DbJournal.Where(i => i.DetailId == nozzle.Id).ToList();
        }

        public IEnumerable<NozzleTCP> GetPoints()
        {
            return DbTCP.ToList();
        }
    }
}