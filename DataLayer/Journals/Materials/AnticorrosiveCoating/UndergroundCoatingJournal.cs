using DataLayer.Entities.Materials.AnticorrosiveCoating;
using DataLayer.TechnicalControlPlans.Materials.AnticorrosiveCoating;

namespace DataLayer.Journals.Materials.AnticorrosiveCoating
{
    public class UndergroundCoatingJournal : BaseJournal<UndergroundCoating, AnticorrosiveCoatingTCP>
    {
        public UndergroundCoatingJournal() { }

        public UndergroundCoatingJournal(UndergroundCoating entity, AnticorrosiveCoatingTCP entityTCP) : base(entity, entityTCP)
        { }

        public UndergroundCoatingJournal(int id, UndergroundCoatingJournal journal) : base(id, journal)
        { }
    }
}
