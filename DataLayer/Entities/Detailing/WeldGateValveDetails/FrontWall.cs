using System.Collections.Generic;
using DataLayer.Journals.Detailing.WeldGateValveDetails;

namespace DataLayer.Entities.Detailing.WeldGateValveDetails
{
    public class FrontWall : BaseDetail
    {
        public FrontWall()
        {
            Name = "Стенка лицевая";
        }

        public int? WeldGateValveCaseId { get; set; }
        public WeldGateValveCase GetWeldGateValveCase { get; set; }

        public int? WeldNozzleId { get; set; }
        public WeldNozzle WeldNozzle { get; set; }

        public IEnumerable<FrontWallJournal> FrontWallJournals{ get; set; }
    }
}
