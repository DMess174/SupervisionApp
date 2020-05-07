using System.Collections.Generic;
using System.Collections.ObjectModel;
using DataLayer.Entities.AssemblyUnits;
using DataLayer.Entities.Materials;
using DataLayer.Files;
using DataLayer.Journals.Detailing.ReverseShutterDetails;

namespace DataLayer.Entities.Detailing.ReverseShutterDetails
{
    public class StubShutter : ReverseShutterDetail
    {
        public StubShutter()
        {
            Name = "Заглушка затвора";
        }
        public StubShutter(StubShutter stub) : base(stub)
        {

        }

        public int? ReverseShutterId { get; set; }

        public ObservableCollection<StubShutterJournal> StubShutterJournals { get; set; }
        public ObservableCollection<StubShutterWithFile> Files { get; set; }
    }
}
