using DataLayer.Entities.AssemblyUnits;
using DataLayer.Entities.Detailing;

namespace DataLayer.Files
{
    public class BaseValveCoverWithFile : BaseTable
    {
        public int BaseValveCoverId { get; set; }
        public BaseValveCover BaseValveCover { get; set; }

        public int ElectronicDocumentId { get; set; }
        public ElectronicDocument ElectronicDocument { get; set; }

        public BaseValveCoverWithFile()
        {
        }

        public BaseValveCoverWithFile(int id, ElectronicDocument file)
        {
            BaseValveCoverId = id;
            ElectronicDocumentId = file.Id;
        }
    }
}
