using System.Collections.Generic;
using System.Collections.ObjectModel;
using DataLayer.Files;
using DataLayer.Journals.Detailing.ReverseShutterDetails;

namespace DataLayer.Entities.Detailing.ReverseShutterDetails
{
    public class SteelSleeveShutter : ReverseShutterDetail
    {
        public SteelSleeveShutter()
        {
            Name = "Втулка стальная";
        }
        public SteelSleeveShutter(SteelSleeveShutter sleeve) : base(sleeve)
        {

        }

        public int? ReverseShutterId { get; set; }

        public ObservableCollection<SteelSleeveShutterJournal> SteelSleeveShutterJournals{ get; set; }
        public ObservableCollection<SteelSleeveShutterWithFile> Files { get; set; }
    }
}
