using DataLayer.Entities.Detailing;

namespace DataLayer.Files
{
    public class RunningSleeveWithFile : BaseTable
    {
        public int RunningSleeveId { get; set; }
        public RunningSleeve RunningSleeve { get; set; }

        public int ElectronicDocumentId { get; set; }
        public ElectronicDocument ElectronicDocument { get; set; }

        public RunningSleeveWithFile()
        {
        }

        public RunningSleeveWithFile(int id, ElectronicDocument file)
        {
            RunningSleeveId = id;
            ElectronicDocumentId = file.Id;
        }
    }
}
