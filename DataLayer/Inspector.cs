using System;
using DataLayer.Journals.Detailing;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using DataLayer.Journals.AssemblyUnits;
using DataLayer.Journals.Detailing.CastGateValveDetails;
using DataLayer.Journals.Detailing.ReverseShutterDetails;

namespace DataLayer
{
    public class Inspector : BaseTable
    {
        public string Name { get; set; }

        public string Subdivision { get; set; }

        public string Department { get; set; }

        [NotMapped] public string FullName => string.Format($"{Name}\n{Department}\n{Subdivision}");

        public IEnumerable<BronzeSleeveShutterJournal> BronzeSleeveShutterJournals { get; set; }
        public IEnumerable<ReverseShutterCaseJournal> ReverseShutterCaseJournals { get; set; }
        public IEnumerable<NozzleJournal> NozzleJournals { get; set; }
        public IEnumerable<ShaftShutterJournal> ShaftShutterJournals { get; set; }
        public IEnumerable<SlamShutterJournal> SlamShutterJournals { get; set; }
        public IEnumerable<SteelSleeveShutterJournal> SteelSleeveShutterJournals { get; set; }
        public IEnumerable<StubShutterJournal> StubShutterJournals { get; set; }
        public IEnumerable<ReverseShutterJournal> ReverseShutterJournals { get; set; }
        public IEnumerable<CastGateValveCaseJournal> CastGateValveCaseJournals { get; set; }
        public IEnumerable<CastGateValveJournal> CastGateValveJournals { get; set; }
    }
}
