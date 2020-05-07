using DataLayer.Entities.Detailing.WeldGateValveDetails;

namespace DataLayer.Files
{
    public class CaseEdgeWithFile : BaseTable
    {
        public int CaseEdgeId { get; set; }
        public CaseEdge CaseEdge { get; set; }

        public int ElectronicDocumentId { get; set; }
        public ElectronicDocument ElectronicDocument { get; set; }

        public CaseEdgeWithFile()
        {
        }

        public CaseEdgeWithFile(int id, ElectronicDocument file)
        {
            CaseEdgeId = id;
            ElectronicDocumentId = file.Id;
        }
    }
}
