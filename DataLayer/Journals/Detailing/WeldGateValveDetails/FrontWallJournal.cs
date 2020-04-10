using DataLayer.Entities.Detailing.WeldGateValveDetails;
using DataLayer.TechnicalControlPlans.Detailing.WeldGateValveDetails;

namespace DataLayer.Journals.Detailing.WeldGateValveDetails
{
    public class FrontWallJournal : BaseJournal<FrontWall, FrontWallTCP>
    {
        public FrontWallJournal() { }

        public FrontWallJournal(FrontWall entity, FrontWallTCP entityTCP) : base(entity, entityTCP)
        { }

        public FrontWallJournal(int id, FrontWallJournal journal) : base(id, journal)
        { }
    }
}
