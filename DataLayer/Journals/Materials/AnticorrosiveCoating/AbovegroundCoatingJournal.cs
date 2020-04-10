using DataLayer.Entities.Materials.AnticorrosiveCoating;
using DataLayer.TechnicalControlPlans.Materials.AnticorrosiveCoating;

namespace DataLayer.Journals.Materials.AnticorrosiveCoating
{
    public class AbovegroundCoatingJournal : BaseJournal<AbovegroundCoating, AnticorrosiveCoatingTCP>
    {
        public AbovegroundCoatingJournal() { }

        public AbovegroundCoatingJournal(AbovegroundCoating entity, AnticorrosiveCoatingTCP entityTCP) : base(entity, entityTCP)
        { }

        public AbovegroundCoatingJournal(int id, AbovegroundCoatingJournal journal) : base(id, journal)
        { }
    }
}
