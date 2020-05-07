using DataLayer.Entities.Detailing;

namespace DataLayer.Files
{
    public class ShearPinWithFile : BaseTable
    {
        public int ShearPinId { get; set; }
        public ShearPin ShearPin { get; set; }

        public int ElectronicDocumentId { get; set; }
        public ElectronicDocument ElectronicDocument { get; set; }

        public ShearPinWithFile()
        {
        }

        public ShearPinWithFile(int id, ElectronicDocument file)
        {
            ShearPinId = id;
            ElectronicDocumentId = file.Id;
        }
    }
}
