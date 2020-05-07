using DataLayer.Entities.Detailing;
using DataLayer.Entities.Detailing.CompactGateValveDetails;
using DataLayer.Entities.Detailing.WeldGateValveDetails;

namespace DataLayer.Files
{
    public class SideWallWithFile : BaseTable
    {
        public int SideWallId { get; set; }
        public SideWall SideWall { get; set; }

        public int ElectronicDocumentId { get; set; }
        public ElectronicDocument ElectronicDocument { get; set; }

        public SideWallWithFile()
        {
        }

        public SideWallWithFile(int id, ElectronicDocument file)
        {
            SideWallId = id;
            ElectronicDocumentId = file.Id;
        }
    }
}
