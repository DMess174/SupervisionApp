using System.Collections.Generic;
using System.Collections.ObjectModel;
using DataLayer.Journals.Detailing.ReverseShutterDetails;

namespace DataLayer.Entities.Detailing.ReverseShutterDetails
{
    public class BronzeSleeveShutter : ReverseShutterDetail
    {
        public BronzeSleeveShutter()
        {
            Name = "Втулка бронзовая";
        }

        public BronzeSleeveShutter(BronzeSleeveShutter sleeve) : base(sleeve)
        {
            Material = sleeve.Material;
            Melt = sleeve.Melt;
        }

        public string Material { get; set; }
        public string Melt { get; set; }

        public int? ReverseShutterId { get; set; }

        public ObservableCollection<BronzeSleeveShutterJournal> BronzeSleeveShutterJournals { get; set; }
    }
}
