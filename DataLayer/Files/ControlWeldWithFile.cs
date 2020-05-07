using DataLayer.Entities.Detailing.WeldGateValveDetails;
using DataLayer.Entities.Materials;

namespace DataLayer.Files
{
    public class ControlWeldWithFile : BaseTable
    {
        public int ControlWeldId { get; set; }
        public ControlWeld ControlWeld { get; set; }

        public int ElectronicDocumentId { get; set; }
        public ElectronicDocument ElectronicDocument { get; set; }

        public ControlWeldWithFile()
        {
        }

        public ControlWeldWithFile(int id, ElectronicDocument file)
        {
            ControlWeldId = id;
            ElectronicDocumentId = file.Id;
        }
    }
}
