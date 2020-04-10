using System.Collections.Generic;
using System.Collections.ObjectModel;
using DataLayer.Journals.Detailing.ReverseShutterDetails;

namespace DataLayer.Entities.Detailing.ReverseShutterDetails
{
    public class ShaftShutter : ReverseShutterDetail
    {
        public ShaftShutter()
        {
            Name = "Ось затвора";
        }
        public ShaftShutter(ShaftShutter shaftShutter) : base(shaftShutter)
        {

        }

        public ObservableCollection<ShaftShutterJournal> ShaftShutterJournals { get; set; }
    }
}
