using DataLayer.Entities.Detailing.ReverseShutterDetails;

namespace DataLayer.Files
{
    public class BronzeSleeveShutterWithFile : BaseTable
    {
        public int BronzeSleeveShutterId { get; set; }
        public BronzeSleeveShutter BronzeSleeveShutter { get; set; }

        public int ElectronicDocumentId { get; set; }
        public ElectronicDocument ElectronicDocument { get; set; }

        public BronzeSleeveShutterWithFile()
        {
        }

        public BronzeSleeveShutterWithFile(int id, ElectronicDocument file)
        {
            BronzeSleeveShutterId = id;
            ElectronicDocumentId = file.Id;
        }
    }
}
