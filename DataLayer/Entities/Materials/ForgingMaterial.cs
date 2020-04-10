using DataLayer.Journals.Materials;
using System.Collections.ObjectModel;

namespace DataLayer.Entities.Materials
{
    public class ForgingMaterial : MetalMaterial
    {
        public ForgingMaterial()
        {
            Name = "Поковка";
        }

        public ForgingMaterial(ForgingMaterial material) : base(material)
        {
        }

        public string MetalCharge { get; set; }

        public ObservableCollection<ForgingMaterialJournal> ForgingMaterialJournals { get; set; }
    }
}
