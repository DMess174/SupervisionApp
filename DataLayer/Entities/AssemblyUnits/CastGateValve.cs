using System.Collections.Generic;
using System.Collections.ObjectModel;
using DataLayer.Entities.Detailing.CastGateValveDetails;
using DataLayer.Journals.AssemblyUnits;

namespace DataLayer.Entities.AssemblyUnits
{
    public class CastGateValve : BaseValve
    {
        public CastGateValve()
        {
            Name = "ЗШ";
        }
        public CastGateValve(CastGateValve valve) : base(valve)
        {

        }

        public int? CastGateValveCaseId { get; set; }
        public CastGateValveCase CastGateValveCase { get; set; }

        public int? CastGateValveCoverId { get; set; }
        public CastGateValveCover CastGateValveCover { get; set; }

        public ObservableCollection<CastGateValveJournal> CastGateValveJournals { get; set; }
    }
}
