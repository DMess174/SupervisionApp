using System.Collections.Generic;
using DataLayer.Journals.Detailing.WeldGateValveDetails;

namespace DataLayer.Entities.Detailing.WeldGateValveDetails
{
    public class SideWall : BaseDetail
    {
        public SideWall()
        {
            Name = "Стенка боковая";
        }

        public int? WeldGateValveCaseId { get; set; }
        public WeldGateValveCase GetWeldGateValveCase { get; set; }

        public IEnumerable<SideWallJournal> SideWallJournals { get; set; }
    }
}
