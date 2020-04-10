using DataLayer.Journals.Materials;
using System.Collections.ObjectModel;

namespace DataLayer.Entities.Materials
{
    public class RolledMaterial : MetalMaterial
    {
        public RolledMaterial()
        {
            Name = "Прокат";
        }


        public RolledMaterial(RolledMaterial material) : base(material)
        { 

        }

        public ObservableCollection<RolledMaterialJournal> RolledMaterialJournals { get; set; }
    }
}
