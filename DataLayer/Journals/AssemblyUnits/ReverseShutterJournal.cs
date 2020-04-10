using DataLayer.Entities.AssemblyUnits;
using DataLayer.TechnicalControlPlans.AssemblyUnits;

namespace DataLayer.Journals.AssemblyUnits
{
    public class ReverseShutterJournal : BaseJournal<ReverseShutter, ReverseShutterTCP>
    {
        public ReverseShutterJournal()
        {

        }
        public ReverseShutterJournal(ReverseShutter entity, ReverseShutterTCP entityTCP) : base(entity, entityTCP)
        { }

        public ReverseShutterJournal(int id, ReverseShutterJournal journal) : base(id, journal)
        { }
    }
}
