using DataLayer.Entities.AssemblyUnits;
using DataLayer.Entities.Materials;
using DataLayer.Journals.Detailing;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DataLayer.Entities.Detailing
{
    public class Gate : BaseEntity
    {
        public Gate()
        {
            Name = "Шибер";
        }

        public Gate(Gate gate) : base(gate)
        {
            MetalMaterialId = gate.MetalMaterialId;
        }

        public int? MetalMaterialId { get; set; }
        public MetalMaterial MetalMaterial { get; set; }

        public int? PIDId { get; set; }
        public PID PID { get; set; }
        public BaseValve BaseValve { get; set; }

        public ObservableCollection<GateJournal> GateJournals { get; set; }
    }
}
