using System.Collections.Generic;

namespace DataLayer.Entities.Detailing
{
    public class BaseCastingCase : BaseDetail
    {
        public IEnumerable<Nozzle> Nozzles { get; set; }
    }
}
