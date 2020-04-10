using DataLayer.Entities.Detailing.CompactGateValveDetails;
using DataLayer.TechnicalControlPlans.Detailing.CompactGateValveDetails;

namespace DataLayer.Journals.Detailing.CompactGateValveDetails
{
    public class ShutterDiskJournal : BaseJournal<ShutterDisk, ShutterDiskTCP>
    {
        public ShutterDiskJournal()
        {

        }
        public ShutterDiskJournal(ShutterDisk entity, ShutterDiskTCP entityTCP) : base(entity, entityTCP)
        { }

        public ShutterDiskJournal(int id, ShutterDiskJournal journal) : base(id, journal)
        { }
    }
}
