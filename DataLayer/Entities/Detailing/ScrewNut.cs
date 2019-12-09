using System.Collections.Generic;
using DataLayer.Entities.AssemblyUnits;
using DataLayer.Journals.Detailing;

namespace DataLayer.Entities.Detailing
{
    public class ScrewNut : Fasteners
    {
        public ScrewNut()
        {
            Name = "Гайка";
        }

        public IEnumerable<BaseValveWithScrewNut> BaseValveWithScrewNuts { get; set; }

        public  IEnumerable<ScrewNutJournal> ScrewNutJournals { get; set; }
    }
}
