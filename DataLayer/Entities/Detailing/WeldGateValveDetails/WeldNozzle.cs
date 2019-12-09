using System.Collections.Generic;
using DataLayer.Journals.Detailing.WeldGateValveDetails;

namespace DataLayer.Entities.Detailing.WeldGateValveDetails
{
    public class WeldNozzle : BaseDetail
    {
        public WeldNozzle()
        {
            Name = "Патрубок";
        }
        public FrontWall FrontWall { get; set; }

        public IEnumerable<WeldNozzleJournal> WeldNozzleJournals { get; set; }
    }
}
