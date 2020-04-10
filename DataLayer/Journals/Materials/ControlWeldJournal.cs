using DataLayer.Entities.Materials;
using DataLayer.TechnicalControlPlans.Materials;

namespace DataLayer.Journals.Materials
{
    public class ControlWeldJournal : BaseJournal<ControlWeld, ControlWeldTCP>
    {
        public ControlWeldJournal() { }

        public ControlWeldJournal(ControlWeld entity, ControlWeldTCP entityTCP) : base(entity, entityTCP)
        { }

        public ControlWeldJournal(int id, ControlWeldJournal journal) : base(id, journal)
        { }
    }
}
