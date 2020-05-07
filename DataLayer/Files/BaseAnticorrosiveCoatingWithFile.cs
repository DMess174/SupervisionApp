using DataLayer.Entities.Materials.AnticorrosiveCoating;

namespace DataLayer.Files
{
    public class BaseAnticorrosiveCoatingWithFile : BaseTable
    {
        public int BaseAnticorrosiveCoatingId { get; set; }
        public BaseAnticorrosiveCoating BaseAnticorrosiveCoating { get; set; }

        public int ElectronicDocumentId { get; set; }
        public ElectronicDocument ElectronicDocument { get; set; }

        public BaseAnticorrosiveCoatingWithFile()
        {
        }

        public BaseAnticorrosiveCoatingWithFile(int id, ElectronicDocument file)
        {
            BaseAnticorrosiveCoatingId = id;
            ElectronicDocumentId = file.Id;
        }
    }
}
