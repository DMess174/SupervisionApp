using System.Collections.Generic;
using System.Collections.ObjectModel;
using DataLayer.Entities.AssemblyUnits;
using DataLayer.Files;
using DataLayer.Journals.Detailing.CompactGateValveDetails;

namespace DataLayer.Entities.Detailing.CompactGateValveDetails
{
    public class Shutter : BaseEntity
    {
        public Shutter()
        {
            Name = "Затвор";
        }
        public Shutter(Shutter shutter) : base(shutter)
        {

        }

        public BaseValve BaseValve { get; set; }

        public ObservableCollection<ShutterDisk> ShutterDisks { get; set; }
        public ObservableCollection<ShutterGuide> ShutterGuides { get; set; }

        public ObservableCollection<ShutterJournal> ShutterJournals { get; set; }
        public ObservableCollection<ShutterWithFile> Files { get; set; }
    }
}
