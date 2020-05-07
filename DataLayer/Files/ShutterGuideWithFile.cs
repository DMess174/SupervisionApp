using DataLayer.Entities.Detailing;
using DataLayer.Entities.Detailing.CompactGateValveDetails;

namespace DataLayer.Files
{
    public class ShutterGuideWithFile : BaseTable
    {
        public int ShutterGuideId { get; set; }
        public ShutterGuide ShutterGuide { get; set; }

        public int ElectronicDocumentId { get; set; }
        public ElectronicDocument ElectronicDocument { get; set; }

        public ShutterGuideWithFile()
        {
        }

        public ShutterGuideWithFile(int id, ElectronicDocument file)
        {
            ShutterGuideId = id;
            ElectronicDocumentId = file.Id;
        }
    }
}
