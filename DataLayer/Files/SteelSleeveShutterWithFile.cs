using DataLayer.Entities.Detailing.ReverseShutterDetails;

namespace DataLayer.Files
{
    public class SteelSleeveShutterWithFile : BaseTable
    {
        public int SteelSleeveShutterId { get; set; }
        public SteelSleeveShutter SteelSleeveShutter { get; set; }

        public int ElectronicDocumentId { get; set; }
        public ElectronicDocument ElectronicDocument { get; set; }

        public SteelSleeveShutterWithFile()
        {
        }

        public SteelSleeveShutterWithFile(int id, ElectronicDocument file)
        {
            SteelSleeveShutterId = id;
            ElectronicDocumentId = file.Id;
        }
    }
}
