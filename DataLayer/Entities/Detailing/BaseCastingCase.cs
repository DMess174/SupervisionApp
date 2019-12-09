using System.Collections.Generic;

namespace DataLayer.Entities.Detailing
{
    public class BaseCastingCase : BaseCase
    {
        public string Material { get; set; }

        public string Certificate { get; set; }

        public string Melt { get; set; }

        public IEnumerable<Nozzle> Nozzles { get; set; }
    }
}
