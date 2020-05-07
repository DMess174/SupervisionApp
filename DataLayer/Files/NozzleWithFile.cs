using DataLayer.Entities.Detailing;
using DataLayer.Entities.Detailing.WeldGateValveDetails;

namespace DataLayer.Files
{
    public class NozzleWithFile : BaseTable
    {
        public int NozzleId { get; set; }
        public Nozzle Nozzle { get; set; }

        public int ElectronicDocumentId { get; set; }
        public ElectronicDocument ElectronicDocument { get; set; }

        public NozzleWithFile()
        {
        }

        public NozzleWithFile(int id, ElectronicDocument file)
        {
            NozzleId = id;
            ElectronicDocumentId = file.Id;
        }
    }
}
