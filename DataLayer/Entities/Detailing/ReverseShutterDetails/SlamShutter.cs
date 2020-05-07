using System.Collections.Generic;
using System.Collections.ObjectModel;
using DataLayer.Entities.AssemblyUnits;
using DataLayer.Files;
using DataLayer.Journals.Detailing.ReverseShutterDetails;

namespace DataLayer.Entities.Detailing.ReverseShutterDetails
{
    public class SlamShutter : BaseEntity
    {
        public SlamShutter()
        {
            Name = "Захлопка";
        }
        public SlamShutter(SlamShutter slamShutter) : base(slamShutter)
        {
            Material = slamShutter.Material;
            Melt = slamShutter.Melt;
        }

        public string Material { get; set; }
        public string Melt { get; set; }

        public ReverseShutter ReverseShutter { get; set; }

        public ObservableCollection<SlamShutterJournal> SlamShutterJournals { get; set; }
        public ObservableCollection<SlamShutterWithFile> Files { get; set; }
    }
}

