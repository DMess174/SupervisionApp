using DataLayer.Entities.Detailing;
using DataLayer.Entities.Detailing.WeldGateValveDetails;

namespace DataLayer.Files
{
    public class CoverSealingRingWithFile : BaseTable
    {
        public int CoverSealingRingId { get; set; }
        public CoverSealingRing CoverSealingRing { get; set; }

        public int ElectronicDocumentId { get; set; }
        public ElectronicDocument ElectronicDocument { get; set; }

        public CoverSealingRingWithFile()
        {
        }

        public CoverSealingRingWithFile(int id, ElectronicDocument file)
        {
            CoverSealingRingId = id;
            ElectronicDocumentId = file.Id;
        }
    }
}
