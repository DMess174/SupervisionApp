using DataLayer.Entities.Detailing.WeldGateValveDetails;
using DataLayer.TechnicalControlPlans.Detailing.WeldGateValveDetails;

namespace DataLayer.Journals.Detailing.WeldGateValveDetails
{
    public class SideWallJournal : BaseJournal<SideWall, SideWallTCP>
    {
        public SideWallJournal() { }

        public SideWallJournal(SideWall entity, SideWallTCP entityTCP) : base(entity, entityTCP)
        { }

        public SideWallJournal(int id, SideWallJournal journal) : base(id, journal)
        { }
    }
}
