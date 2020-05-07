namespace DataLayer.Files
{
    public class SpecificationWithFile : BaseTable
    {
        public int SpecificationId { get; set; }
        public Specification Specification { get; set; }

        public int ElectronicDocumentId { get; set; }
        public ElectronicDocument ElectronicDocument { get; set; }

        public SpecificationWithFile()
        {
        }

        public SpecificationWithFile(int specificationId, ElectronicDocument file)
        {
            SpecificationId = specificationId;
            ElectronicDocumentId = file.Id;
        }
    }
}
