using DataLayer.Entities.AssemblyUnits;
using DataLayer.Entities.Materials;
using DataLayer.Files;
using DataLayer.Journals.Detailing;
using System.Collections.ObjectModel;

namespace DataLayer.Entities.Detailing
{
    public class Saddle : BaseEntity
    {
        public Saddle()
        {
            Name = "Седло";
        }

        public Saddle(Saddle saddle) : base(saddle)
        {
            MetalMaterialId = saddle.MetalMaterialId;
        }

        public int? MetalMaterialId { get; set; }
        public MetalMaterial MetalMaterial { get; set; }

        public int? BaseValveId{ get; set; }
        public BaseValve BaseValve { get; set; }

        public ObservableCollection<SaddleWithSealing> SaddleWithSealings { get; set; }

        public ObservableCollection<SaddleJournal> SaddleJournals { get; set; }
        public ObservableCollection<SaddleWithFile> Files { get; set; }
    }
}
