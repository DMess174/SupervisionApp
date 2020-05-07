using DataLayer.Entities.Detailing;
using DataLayer.Entities.Detailing.WeldGateValveDetails;

namespace DataLayer.Files
{
    public class FrontalSaddleSealingWithFile : BaseTable
    {
        public int FrontalSaddleSealingId { get; set; }
        public FrontalSaddleSealing FrontalSaddleSealing { get; set; }

        public int ElectronicDocumentId { get; set; }
        public ElectronicDocument ElectronicDocument { get; set; }

        public FrontalSaddleSealingWithFile()
        {
        }

        public FrontalSaddleSealingWithFile(int id, ElectronicDocument file)
        {
            FrontalSaddleSealingId = id;
            ElectronicDocumentId = file.Id;
        }
    }
}
