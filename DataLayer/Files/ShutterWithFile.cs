using DataLayer.Entities.Detailing;
using DataLayer.Entities.Detailing.CompactGateValveDetails;

namespace DataLayer.Files
{
    public class ShutterWithFile : BaseTable
    {
        public int ShutterId { get; set; }
        public Shutter Shutter { get; set; }

        public int ElectronicDocumentId { get; set; }
        public ElectronicDocument ElectronicDocument { get; set; }

        public ShutterWithFile()
        {
        }

        public ShutterWithFile(int id, ElectronicDocument file)
        {
            ShutterId = id;
            ElectronicDocumentId = file.Id;
        }
    }
}
