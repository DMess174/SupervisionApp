using DataLayer.Entities.AssemblyUnits;
using DataLayer.Entities.Materials;
using DataLayer.Journals.Detailing;
using System.Collections.ObjectModel;

namespace DataLayer.Entities.Detailing
{
    public class CounterFlange : BaseEntity
    {
        public CounterFlange()
        {
            Name = "Фланец ответный";
        }

        public CounterFlange(CounterFlange flange) : base(flange)
        {
            MetalMaterialId = flange.MetalMaterialId;
        }

        public string ThicknessJoining { get; set; }

        public int? MetalMaterialId { get; set; }
        public MetalMaterial MetalMaterial { get; set; }

        public int? BaseValveId { get; set; }
        public BaseValve BaseValve { get; set; }

        public ObservableCollection<CounterFlangeJournal> CounterFlangeJournals { get; set; }
    }
}
