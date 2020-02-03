using BusinessLayer.Repository.Interfaces.Entities.Detailing;
using DataLayer;
using DataLayer.Entities.Detailing.ReverseShutterDetails;
using DataLayer.Journals.Detailing.ReverseShutterDetails;
using DataLayer.TechnicalControlPlans.Detailing.ReverseShutterDetails;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Repository.Implementations.Entities.Detailing.ReverseShutter
{
    public class BronzeSleeveShutterRepository : RepositoryWithJournal<BronzeSleeveShutter, BronzeSleeveShutterJournal, BronzeSleeveShutterTCP>, IBronzeSleeveShutterRepository
    {
        public BronzeSleeveShutterRepository(DataContext context) : base(context)
        {
        }

        public override BronzeSleeveShutter AddCopy(BronzeSleeveShutter entity)
        {
            return base.AddCopy(entity);
        }

        public override Task<BronzeSleeveShutter> AddCopyAsync(BronzeSleeveShutter entity)
        {
            return base.AddCopyAsync(entity);
        }
        
        public override Task<int> AddJournalRecordAsync(BronzeSleeveShutter entity, IEnumerable<BronzeSleeveShutterJournal> entities)
        {
            return base.AddJournalRecordAsync(entity, entities);
        }
    }
}
