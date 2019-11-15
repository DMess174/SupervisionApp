using DataLayer;
using DataLayer.Journals.Detailing;
using System.Collections.Generic;

namespace Supervision.ViewModels
{
    public class InspectorDTO : BasePropertyChanged
    {
        public InspectorDTO()
        {
        }

        public InspectorDTO(Inspector item)
        {
            Id = item.Id;
            Name = item.Name;
            Subdivision = item.Subdivision;
            Department = item.Department;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Subdivision { get; set; }

        public string Department { get; set; }

        public List<BronzeSleeveShutterJournal> BronzeSleeveShutterJournals { get; set; }
        public List<CaseShutterJournal> CaseShutterJournals{ get; set; }
        public List<NozzleJournal> NozzleJournals{ get; set; }
        public List<ShaftShutterJournal> ShaftShutterJournals{ get; set; }
        public List<SlamShutterJournal> SlamShutterJournals{ get; set; }
        public List<SteelSleeveShutterJournal> SteelSleeveShutterJournals{ get; set; }
        public List<StubShutterJournal> StubShutterJournals{ get; set; }
        public List<ShutterReverseJournal> ShutterReverseJournals{ get; set; }


    }
}
