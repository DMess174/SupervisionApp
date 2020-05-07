using DataLayer.Entities.Detailing;
using DataLayer.Entities.Detailing.CompactGateValveDetails;
using DataLayer.Entities.Detailing.WeldGateValveDetails;

namespace DataLayer.Files
{
    public class SpindleWithFile : BaseTable
    {
        public int SpindleId { get; set; }
        public Spindle Spindle { get; set; }

        public int ElectronicDocumentId { get; set; }
        public ElectronicDocument ElectronicDocument { get; set; }

        public SpindleWithFile()
        {
        }

        public SpindleWithFile(int id, ElectronicDocument file)
        {
            SpindleId = id;
            ElectronicDocumentId = file.Id;
        }
    }
}
