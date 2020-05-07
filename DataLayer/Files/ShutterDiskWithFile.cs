using DataLayer.Entities.Detailing;
using DataLayer.Entities.Detailing.CompactGateValveDetails;

namespace DataLayer.Files
{
    public class ShutterDiskWithFile : BaseTable
    {
        public int ShutterDiskId { get; set; }
        public ShutterDisk ShutterDisk { get; set; }

        public int ElectronicDocumentId { get; set; }
        public ElectronicDocument ElectronicDocument { get; set; }

        public ShutterDiskWithFile()
        {
        }

        public ShutterDiskWithFile(int id, ElectronicDocument file)
        {
            ShutterDiskId = id;
            ElectronicDocumentId = file.Id;
        }
    }
}
