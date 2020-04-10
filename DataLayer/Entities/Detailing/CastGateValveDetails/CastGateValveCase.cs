using System.Collections.Generic;
using System.Collections.ObjectModel;
using DataLayer.Entities.AssemblyUnits;
using DataLayer.Journals.Detailing.CastGateValveDetails;

namespace DataLayer.Entities.Detailing.CastGateValveDetails
{
    public class CastGateValveCase : BaseCastingCase
    {
        public CastGateValveCase()
        {
            Name = "Корпус ЗШ";
        }
        public CastGateValveCase(CastGateValveCase valveCase) : base(valveCase)
        {
            Material = valveCase.Material;
            Melt = valveCase.Melt;
        }

        public CastGateValve CastGateValve { get; set; }

        public ObservableCollection<CastGateValveCaseJournal> CastGateValveCaseJournals { get; set; }
    }
}
