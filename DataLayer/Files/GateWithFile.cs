using DataLayer.Entities.Detailing;
using DataLayer.Entities.Detailing.WeldGateValveDetails;

namespace DataLayer.Files
{
    public class GateWithFile : BaseTable
    {
        public int GateId { get; set; }
        public Gate Gate { get; set; }

        public int ElectronicDocumentId { get; set; }
        public ElectronicDocument ElectronicDocument { get; set; }

        public GateWithFile()
        {
        }

        public GateWithFile(int id, ElectronicDocument file)
        {
            GateId = id;
            ElectronicDocumentId = file.Id;
        }
    }
}
