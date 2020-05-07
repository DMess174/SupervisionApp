using DataLayer.Entities.AssemblyUnits;
using DataLayer.Entities.Detailing;

namespace DataLayer.Files
{
    public class BallValvesWithFile : BaseTable
    {
        public int BallValveId { get; set; }
        public BallValve BallValves { get; set; }

        public int ElectronicDocumentId { get; set; }
        public ElectronicDocument ElectronicDocument { get; set; }

        public BallValvesWithFile()
        {
        }

        public BallValvesWithFile(int id, ElectronicDocument file)
        {
            BallValveId = id;
            ElectronicDocumentId = file.Id;
        }
    }
}
