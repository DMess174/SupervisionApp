using DataLayer.Entities.Detailing;
using DataLayer.Entities.Detailing.CompactGateValveDetails;
using DataLayer.Entities.Detailing.WeldGateValveDetails;

namespace DataLayer.Files
{
    public class SpringWithFile : BaseTable
    {
        public int SpringId { get; set; }
        public Spring Spring { get; set; }

        public int ElectronicDocumentId { get; set; }
        public ElectronicDocument ElectronicDocument { get; set; }

        public SpringWithFile()
        {
        }

        public SpringWithFile(int id, ElectronicDocument file)
        {
            SpringId = id;
            ElectronicDocumentId = file.Id;
        }
    }
}
