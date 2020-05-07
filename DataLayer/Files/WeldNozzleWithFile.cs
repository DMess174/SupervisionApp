using DataLayer.Entities.Detailing.ReverseShutterDetails;
using DataLayer.Entities.Detailing.WeldGateValveDetails;

namespace DataLayer.Files
{
    public class WeldNozzleWithFile : BaseTable
    {
        public int WeldNozzleId { get; set; }
        public WeldNozzle WeldNozzle { get; set; }

        public int ElectronicDocumentId { get; set; }
        public ElectronicDocument ElectronicDocument { get; set; }

        public WeldNozzleWithFile()
        {
        }

        public WeldNozzleWithFile(int id, ElectronicDocument file)
        {
            WeldNozzleId = id;
            ElectronicDocumentId = file.Id;
        }
    }
}
