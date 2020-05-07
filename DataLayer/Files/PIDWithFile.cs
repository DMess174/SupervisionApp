namespace DataLayer.Files
{
    public class PIDWithFile : BaseTable
    {
        public int PIDId { get; set; }
        public PID PID { get; set; }

        public int ElectronicDocumentId { get; set; }
        public ElectronicDocument ElectronicDocument { get; set; }

        public PIDWithFile()
        {
        }

        public PIDWithFile(int id, ElectronicDocument file)
        {
            PIDId = id;
            ElectronicDocumentId = file.Id;
        }
    }
}
