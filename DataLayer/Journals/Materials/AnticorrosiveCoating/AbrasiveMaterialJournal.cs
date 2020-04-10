using DataLayer.Entities.Materials.AnticorrosiveCoating;
using DataLayer.TechnicalControlPlans.Materials.AnticorrosiveCoating;

namespace DataLayer.Journals.Materials.AnticorrosiveCoating
{
    public class AbrasiveMaterialJournal : BaseJournal<AbrasiveMaterial, AnticorrosiveCoatingTCP>
    {
        public AbrasiveMaterialJournal() { }

        public AbrasiveMaterialJournal(AbrasiveMaterial entity, AnticorrosiveCoatingTCP entityTCP) : base(entity, entityTCP)
        { }

        public AbrasiveMaterialJournal(int id, AbrasiveMaterialJournal journal) : base(id, journal)
        { }
    }
}
