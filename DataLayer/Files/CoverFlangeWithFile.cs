using DataLayer.Entities.Detailing;
using DataLayer.Entities.Detailing.WeldGateValveDetails;

namespace DataLayer.Files
{
    public class CoverFlangeWithFile : BaseTable
    {
        public int CoverFlangeId { get; set; }
        public CoverFlange CoverFlange { get; set; }

        public int ElectronicDocumentId { get; set; }
        public ElectronicDocument ElectronicDocument { get; set; }

        public CoverFlangeWithFile()
        {
        }

        public CoverFlangeWithFile(int id, ElectronicDocument file)
        {
            CoverFlangeId = id;
            ElectronicDocumentId = file.Id;
        }
    }
}
