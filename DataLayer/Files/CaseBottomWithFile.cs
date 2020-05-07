using DataLayer.Entities.Detailing.WeldGateValveDetails;

namespace DataLayer.Files
{
    public class CaseBottomWithFile : BaseTable
    {
        public int CaseBottomId { get; set; }
        public CaseBottom CaseBottom { get; set; }

        public int ElectronicDocumentId { get; set; }
        public ElectronicDocument ElectronicDocument { get; set; }

        public CaseBottomWithFile()
        {
        }

        public CaseBottomWithFile(int id, ElectronicDocument file)
        {
            CaseBottomId = id;
            ElectronicDocumentId = file.Id;
        }
    }
}
