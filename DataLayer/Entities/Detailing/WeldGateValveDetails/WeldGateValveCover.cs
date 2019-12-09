using System.Collections.Generic;
using DataLayer.Entities.AssemblyUnits;
using DataLayer.Journals.Detailing.WeldGateValveDetails;

namespace DataLayer.Entities.Detailing.WeldGateValveDetails
{
    public class WeldGateValveCover : BaseEntity
    {
        public int? CoverFlangeId { get; set; }
        public CoverFlange CoverFlange { get; set; }

        public int? CoverSleeveId { get; set; }
        public CoverSleeve CoverSleeve { get; set; }

        public BaseWeldValve BaseWeldValve { get; set; }
    }
}
