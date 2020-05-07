using DataLayer.Entities.Detailing.WeldGateValveDetails;

namespace DataLayer.Files
{
    public class CaseFlangeWithFile : BaseTable
    {
        public int CaseFlangeId { get; set; }
        public CaseFlange CaseFlange { get; set; }

        public int ElectronicDocumentId { get; set; }
        public ElectronicDocument ElectronicDocument { get; set; }

        public CaseFlangeWithFile()
        {
        }

        public CaseFlangeWithFile(int id, ElectronicDocument file)
        {
            CaseFlangeId = id;
            ElectronicDocumentId = file.Id;
        }
    }
}
