using DataLayer.Entities.Detailing.ReverseShutterDetails;
using DataLayer.Entities.Detailing.WeldGateValveDetails;

namespace DataLayer.Files
{
    public class WeldGateValveCaseWithFile : BaseTable
    {
        public int WeldGateValveCaseId { get; set; }
        public WeldGateValveCase WeldGateValveCase { get; set; }

        public int ElectronicDocumentId { get; set; }
        public ElectronicDocument ElectronicDocument { get; set; }

        public WeldGateValveCaseWithFile()
        {
        }

        public WeldGateValveCaseWithFile(int id, ElectronicDocument file)
        {
            WeldGateValveCaseId = id;
            ElectronicDocumentId = file.Id;
        }
    }
}
