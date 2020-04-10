using System.Collections.Generic;
using System.Collections.ObjectModel;
using DataLayer.Entities.AssemblyUnits;
using DataLayer.Journals.Detailing.CastGateValveDetails;

namespace DataLayer.Entities.Detailing.CastGateValveDetails
{
    public class CastGateValveCover : BaseValveCover
    {
        public CastGateValveCover()
        {
            Name = "Крышка ЗШ";
        }
        public CastGateValveCover(CastGateValveCover cover) : base(cover)
        {
            Material = cover.Material;
            Melt = cover.Melt;
        }

        public string Material { get; set; }

        public string Melt { get; set; }

        public int? CoverSealingRingId { get; set; }
        public CoverSealingRing CoverSealingRing { get; set; }

        public CastGateValve CastGateValve { get; set; }

        public ObservableCollection<CastGateValveCoverJournal> CastGateValveCoverJournals { get; set; }
    }
}
