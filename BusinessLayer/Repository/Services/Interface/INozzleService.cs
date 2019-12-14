using DataLayer.Entities.Detailing;
using DataLayer.Journals.Detailing;
using DataLayer.TechnicalControlPlans.Detailing;

namespace BusinessLayer.Repository.Services.Interface
{
    public interface INozzleService : IBaseService<Nozzle, NozzleJournal, NozzleTCP>
    {
        
    }
}