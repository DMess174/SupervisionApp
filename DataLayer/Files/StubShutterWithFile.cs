using DataLayer.Entities.Detailing.ReverseShutterDetails;

namespace DataLayer.Files
{
    public class StubShutterWithFile : BaseTable
    {
        public int StubShutterId { get; set; }
        public StubShutter StubShutter { get; set; }

        public int ElectronicDocumentId { get; set; }
        public ElectronicDocument ElectronicDocument { get; set; }

        public StubShutterWithFile()
        {
        }

        public StubShutterWithFile(int id, ElectronicDocument file)
        {
            StubShutterId = id;
            ElectronicDocumentId = file.Id;
        }
    }
}
