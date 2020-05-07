using DataLayer.Entities.Detailing.ReverseShutterDetails;
using DataLayer.Entities.Detailing.WeldGateValveDetails;
using DataLayer.Entities.Materials;

namespace DataLayer.Files
{
    public class WeldingMaterialWithFile : BaseTable
    {
        public int WeldingMaterialId { get; set; }
        public WeldingMaterial WeldingMaterial { get; set; }

        public int ElectronicDocumentId { get; set; }
        public ElectronicDocument ElectronicDocument { get; set; }

        public WeldingMaterialWithFile()
        {
        }

        public WeldingMaterialWithFile(int id, ElectronicDocument file)
        {
            WeldingMaterialId = id;
            ElectronicDocumentId = file.Id;
        }
    }
}
