using DataLayer.Entities.Detailing;
using DataLayer.Entities.Detailing.WeldGateValveDetails;

namespace DataLayer.Files
{
    public class CoverSleeveWithFile : BaseTable
    {
        public int CoverSleeveId { get; set; }
        public CoverSleeve CoverSleeve { get; set; }

        public int ElectronicDocumentId { get; set; }
        public ElectronicDocument ElectronicDocument { get; set; }

        public CoverSleeveWithFile()
        {
        }

        public CoverSleeveWithFile(int id, ElectronicDocument file)
        {
            CoverSleeveId = id;
            ElectronicDocumentId = file.Id;
        }
    }
}
