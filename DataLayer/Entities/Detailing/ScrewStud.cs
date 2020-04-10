using System.Collections.Generic;
using System.Collections.ObjectModel;
using DataLayer.Entities.AssemblyUnits;
using DataLayer.Journals.Detailing;

namespace DataLayer.Entities.Detailing
{
    public class ScrewStud : Fasteners
    {
        public ScrewStud()
        {
            Name = "Шпилька";
        }

        public ScrewStud(ScrewStud screwStud) : base(screwStud)
        {

        }

        public ObservableCollection<BaseValveWithScrewStud> BaseValveWithScrewStuds { get; set; }

        public ObservableCollection<ScrewStudJournal> ScrewStudJournals { get; set; }
    }
}
