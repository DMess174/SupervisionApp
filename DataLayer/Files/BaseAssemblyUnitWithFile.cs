using DataLayer.Entities.AssemblyUnits;

namespace DataLayer.Files
{
    public class BaseAssemblyUnitWithFile : BaseTable
    {
        public int BaseAssemblyUnitId { get; set; }
        public BaseAssemblyUnit BaseAssemblyUnit { get; set; }

        public int ElectronicDocumentId { get; set; }
        public ElectronicDocument ElectronicDocument { get; set; }

        public BaseAssemblyUnitWithFile()
        {
        }

        public BaseAssemblyUnitWithFile(int id, ElectronicDocument file)
        {
            BaseAssemblyUnitId = id;
            ElectronicDocumentId = file.Id;
        }
    }
}
