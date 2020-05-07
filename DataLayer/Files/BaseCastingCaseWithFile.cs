using DataLayer.Entities.Detailing;
using DataLayer.Entities.Detailing.CastGateValveDetails;

namespace DataLayer.Files
{
    public class BaseCastingCaseWithFile : BaseTable
    {
        public int BaseCastingCaseId { get; set; }
        public BaseCastingCase BaseCastingCase { get; set; }

        public int ElectronicDocumentId { get; set; }
        public ElectronicDocument ElectronicDocument { get; set; }

        public BaseCastingCaseWithFile()
        {
        }

        public BaseCastingCaseWithFile(int id, ElectronicDocument file)
        {
            BaseCastingCaseId = id;
            ElectronicDocumentId = file.Id;
        }
    }
}
