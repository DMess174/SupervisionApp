using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLayer.Repository.Interfaces;
using BusinessLayer.Repository.Services.Interface;
using DataLayer.Entities.Detailing;
using DataLayer.Journals.Detailing;

namespace BusinessLayer.Repository.Services
{
    public class NozzleService : INozzleService
    {
        private readonly IUnitOfWorkFactory unitOfWorkFactory;

        public NozzleService(IUnitOfWorkFactory UnitOfWorkFactory)
        {
            unitOfWorkFactory = UnitOfWorkFactory ?? throw new ArgumentNullException(nameof(UnitOfWorkFactory));
        }

        public async Task<QueryResult<Nozzle>> CreateItemAsync()
        {
            var unitOfWork = unitOfWorkFactory.MakeUnitOfWork();
            try
            {
                var nozzle = new Nozzle();
                var entity = await unitOfWork.Nozzle.EntityAddAsync(nozzle);
                await unitOfWork.CompleteAsync();
                return QueryResult<Nozzle>.Success(nozzle);
            }
            catch (Exception ex)
            {
                return QueryResult<Nozzle>.Failure().AddError(ex.Message);
            }
        }

        public async Task<QueryResult<NozzleJournal>> CreateJournalAsync(Nozzle nozzle)
        { 
            throw new NotImplementedException();

        }

        public Task<QueryResult<Nozzle>> EditItemAsync(Nozzle edit)
        {
            throw new NotImplementedException();
        }

        public Task<QueryResult<Nozzle>> DeleteItemAsync(Nozzle delete)
        {
            throw new NotImplementedException();
        }
    }
}