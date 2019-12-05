using System.Collections.Generic;

namespace DataLayer.Entities.Detailing
{
    public class BaseCastingCase : BaseEntity
    {
        public string Material { get; set; }

        public string Certificate { get; set; }

        public string Melt { get; set; }

        public ICollection<Nozzle> Nozzles { get; set; } = new List<Nozzle>(2);

    }
}
