using DataLayer.Journals.Materials;
using System.Collections.ObjectModel;

namespace DataLayer.Entities.Materials
{
    public class PipeMaterial : MetalMaterial
    {
        public PipeMaterial()
        {
            Name = "Труба";
        }

        public PipeMaterial(PipeMaterial material) : base(material)
        {

        }

        public ObservableCollection<PipeMaterialJournal> PipeMaterialJournals { get; set; }
    }
}
