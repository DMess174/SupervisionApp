using DataLayer.Entities.AssemblyUnits;
using DataLayer.Entities.Materials;
using DataLayer.Journals.Detailing;
using System.Collections.Generic;

namespace DataLayer.Entities.Detailing
{
    public class CounterFlange : BaseDetail
    {
        public CounterFlange()
        {
            Name = "Фланец ответный";
        }

        public int? MetalMaterialId { get; set; }
        public MetalMaterial MetalMaterial { get; set; }

        public int? BaseValveId { get; set; }
        public BaseValve BaseValve { get; set; }

        public IEnumerable<CounterFlangeJournal> CounterFlangeJournals { get; set; }
    }
}
