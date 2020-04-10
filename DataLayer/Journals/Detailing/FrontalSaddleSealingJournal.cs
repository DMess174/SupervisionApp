using DataLayer.Entities.Detailing;
using DataLayer.TechnicalControlPlans.Detailing;

namespace DataLayer.Journals.Detailing
{
    public class FrontalSaddleSealingJournal : BaseJournal<FrontalSaddleSealing, FrontalSaddleSealingTCP>
    {
        public FrontalSaddleSealingJournal() { }

        public FrontalSaddleSealingJournal(FrontalSaddleSealing entity, FrontalSaddleSealingTCP entityTCP) : base(entity, entityTCP)
        { }

        public FrontalSaddleSealingJournal(int id, FrontalSaddleSealingJournal journal) : base(id, journal)
        { }
    }
}
