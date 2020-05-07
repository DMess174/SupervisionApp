using DataLayer.Entities.Materials;

namespace DataLayer.Files
{
    public class MetalMaterialWithFile : BaseTable
    {
        public int MetalMaterialId { get; set; }
        public MetalMaterial MetalMaterial { get; set; }

        public int ElectronicDocumentId { get; set; }
        public ElectronicDocument ElectronicDocument { get; set; }

        public MetalMaterialWithFile()
        {
        }

        public MetalMaterialWithFile(int id, ElectronicDocument file)
        {
            MetalMaterialId = id;
            ElectronicDocumentId = file.Id;
        }
    }
}
