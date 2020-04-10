using DataLayer.Entities.Detailing;
using DataLayer.TechnicalControlPlans.Detailing;

namespace DataLayer.Journals.Detailing
{
    public class ShearPinJournal : BaseJournal<ShearPin, ShearPinTCP>
    {
        public ShearPinJournal() { }

        public ShearPinJournal(ShearPin entity, ShearPinTCP entityTCP) : base(entity, entityTCP)
        { }

        public ShearPinJournal(int id, ShearPinJournal journal) : base(id, journal)
        { }
    }
}
