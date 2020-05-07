using DataLayer.Entities.Detailing;

namespace DataLayer.Files
{
    public class ScrewStudWithFile : BaseTable
    {
        public int ScrewStudId { get; set; }
        public ScrewStud ScrewStud { get; set; }

        public int ElectronicDocumentId { get; set; }
        public ElectronicDocument ElectronicDocument { get; set; }

        public ScrewStudWithFile()
        {
        }

        public ScrewStudWithFile(int id, ElectronicDocument file)
        {
            ScrewStudId = id;
            ElectronicDocumentId = file.Id;
        }
    }
}
