using DataLayer.Entities.Detailing;

namespace DataLayer.Files
{
    public class CounterFlangeWithFile : BaseTable
    {
        public int CounterFlangeId { get; set; }
        public CounterFlange CounterFlange { get; set; }

        public int ElectronicDocumentId { get; set; }
        public ElectronicDocument ElectronicDocument { get; set; }

        public CounterFlangeWithFile()
        {
        }

        public CounterFlangeWithFile(int id, ElectronicDocument file)
        {
            CounterFlangeId = id;
            ElectronicDocumentId = file.Id;
        }
    }
}
