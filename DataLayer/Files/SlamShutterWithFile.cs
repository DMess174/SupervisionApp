using DataLayer.Entities.Detailing;
using DataLayer.Entities.Detailing.CompactGateValveDetails;
using DataLayer.Entities.Detailing.ReverseShutterDetails;
using DataLayer.Entities.Detailing.WeldGateValveDetails;

namespace DataLayer.Files
{
    public class SlamShutterWithFile : BaseTable
    {
        public int SlamShutterId { get; set; }
        public SlamShutter SlamShutter { get; set; }

        public int ElectronicDocumentId { get; set; }
        public ElectronicDocument ElectronicDocument { get; set; }

        public SlamShutterWithFile()
        {
        }

        public SlamShutterWithFile(int id, ElectronicDocument file)
        {
            SlamShutterId = id;
            ElectronicDocumentId = file.Id;
        }
    }
}
