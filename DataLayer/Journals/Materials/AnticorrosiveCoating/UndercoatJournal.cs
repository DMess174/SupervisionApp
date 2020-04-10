using DataLayer.Entities.Materials.AnticorrosiveCoating;
using DataLayer.TechnicalControlPlans.Materials.AnticorrosiveCoating;

namespace DataLayer.Journals.Materials.AnticorrosiveCoating
{
    public class UndercoatJournal : BaseJournal<Undercoat, AnticorrosiveCoatingTCP>
    {
        public UndercoatJournal() { }

        public UndercoatJournal(Undercoat entity, AnticorrosiveCoatingTCP entityTCP) : base(entity, entityTCP)
        { }

        public UndercoatJournal(int id, UndercoatJournal journal) : base(id, journal)
        { }
    }
}
