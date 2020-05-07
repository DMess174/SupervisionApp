using DataLayer.Entities.AssemblyUnits;
using DataLayer.Entities.Detailing;

namespace DataLayer.Files
{
    public class AssemblyUnitSealsWithFile : BaseTable
    {
        public int AssemblyUnitSealingId { get; set; }
        public AssemblyUnitSealing AssemblyUnitSealing { get; set; }

        public int ElectronicDocumentId { get; set; }
        public ElectronicDocument ElectronicDocument { get; set; }

        public AssemblyUnitSealsWithFile()
        {
        }

        public AssemblyUnitSealsWithFile(int id, ElectronicDocument file)
        {
            AssemblyUnitSealingId = id;
            ElectronicDocumentId = file.Id;
        }
    }
}
