using DataLayer.Entities.Detailing;
using DataLayer.TechnicalControlPlans.Detailing;

namespace DataLayer.Journals.Detailing
{
    public class CoverSealingRingJournal : BaseJournal<CoverSealingRing, CoverSealingRingTCP>
    {
        public CoverSealingRingJournal() { }

        public CoverSealingRingJournal(CoverSealingRing entity, CoverSealingRingTCP entityTCP) : base(entity, entityTCP)
        { }

        public CoverSealingRingJournal(int id, CoverSealingRingJournal journal) : base(id, journal)
        { }
    }
}
