using DataLayer.Entities.Detailing;

namespace DataLayer.Files
{
    public class SaddleWithFile : BaseTable
    {
        public int SaddleId { get; set; }
        public Saddle Saddle { get; set; }

        public int ElectronicDocumentId { get; set; }
        public ElectronicDocument ElectronicDocument { get; set; }

        public SaddleWithFile()
        {
        }

        public SaddleWithFile(int id, ElectronicDocument file)
        {
            SaddleId = id;
            ElectronicDocumentId = file.Id;
        }
    }
}
