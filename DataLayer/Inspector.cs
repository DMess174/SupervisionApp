using DataLayer.Journals.Detailing;
using System.Collections.Generic;

namespace DataLayer
{
    public class Inspector : BasePropertyChanged
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Subdivision { get; set; }

        public string Department { get; set; }

        public IEnumerable<BronzeSleeveShutterJournal> BronzeSleeveShutterJournals { get; set; }
        public IEnumerable<ShutterCaseJournal> CaseShutterJournals{ get; set; }
        public IEnumerable<NozzleJournal> NozzleJournals{ get; set; }
        public IEnumerable<ShaftShutterJournal> ShaftShutterJournals{ get; set; }
        public IEnumerable<SlamShutterJournal> SlamShutterJournals{ get; set; }
        public IEnumerable<SteelSleeveShutterJournal> SteelSleeveShutterJournals{ get; set; }
        public IEnumerable<StubShutterJournal> StubShutterJournals{ get; set; }
        public IEnumerable<ShutterReverseJournal> ShutterReverseJournals{ get; set; }
        public IEnumerable<ValveCaseJournal> ValveCaseJournals { get; set; }
    }
}
