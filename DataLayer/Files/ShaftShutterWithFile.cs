using DataLayer.Entities.Detailing;
using DataLayer.Entities.Detailing.ReverseShutterDetails;

namespace DataLayer.Files
{
    public class ShaftShutterWithFile : BaseTable
    {
        public int ShaftShutterId { get; set; }
        public ShaftShutter ShaftShutter { get; set; }

        public int ElectronicDocumentId { get; set; }
        public ElectronicDocument ElectronicDocument { get; set; }

        public ShaftShutterWithFile()
        {
        }

        public ShaftShutterWithFile(int id, ElectronicDocument file)
        {
            ShaftShutterId = id;
            ElectronicDocumentId = file.Id;
        }
    }
}
