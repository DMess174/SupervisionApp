using DataLayer.Journals.Detailing;
using System.Collections.Generic;
using DataLayer.Entities.AssemblyUnits;

namespace DataLayer.Entities.Detailing
{
    public class BallValve : BaseEntity
    {
        public string Material { get; set; }
        public string Diameter { get; set; }
        public string Pressure { get; set; }

        public BallValve()
        {
            Name = "Кран шаровой";
        }

        public int? BaseValveId { get; set; }
        public BaseValve BaseValve { get; set; }

        public IEnumerable<BallValveJournal> BallValveJournals { get; set; }
    }
}
