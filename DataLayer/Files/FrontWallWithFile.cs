using DataLayer.Entities.Detailing;
using DataLayer.Entities.Detailing.WeldGateValveDetails;

namespace DataLayer.Files
{
    public class FrontWallWithFile : BaseTable
    {
        public int FrontWallId { get; set; }
        public FrontWall FrontWall { get; set; }

        public int ElectronicDocumentId { get; set; }
        public ElectronicDocument ElectronicDocument { get; set; }

        public FrontWallWithFile()
        {
        }

        public FrontWallWithFile(int id, ElectronicDocument file)
        {
            FrontWallId = id;
            ElectronicDocumentId = file.Id;
        }
    }
}
