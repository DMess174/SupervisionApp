using DataLayer.Entities.Detailing;
using DataLayer.TechnicalControlPlans.Detailing;

namespace DataLayer.Journals.Detailing
{
    public class CounterFlangeJournal : BaseJournal<CounterFlange, CounterFlangeTCP>
    {
        public CounterFlangeJournal() { }

        public CounterFlangeJournal(CounterFlange entity, CounterFlangeTCP entityTCP) : base(entity, entityTCP)
        { }

        public CounterFlangeJournal(int id, CounterFlangeJournal journal) : base(id, journal)
        { }
    }
}
