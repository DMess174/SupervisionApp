using DataLayer.Entities.Detailing;

namespace DataLayer.Files
{
    public class ScrewNutWithFile : BaseTable
    {
        public int ScrewNutId { get; set; }
        public ScrewNut ScrewNut { get; set; }

        public int ElectronicDocumentId { get; set; }
        public ElectronicDocument ElectronicDocument { get; set; }

        public ScrewNutWithFile()
        {
        }

        public ScrewNutWithFile(int id, ElectronicDocument file)
        {
            ScrewNutId = id;
            ElectronicDocumentId = file.Id;
        }
    }
}
