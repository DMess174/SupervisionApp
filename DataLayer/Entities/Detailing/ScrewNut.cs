using System.Collections.Generic;
using System.Collections.ObjectModel;
using DataLayer.Entities.AssemblyUnits;
using DataLayer.Files;
using DataLayer.Journals.Detailing;

namespace DataLayer.Entities.Detailing
{
    public class ScrewNut : Fasteners
    {
        public ScrewNut()
        {
            Name = "Гайка";
        }

        public ScrewNut(ScrewNut screwNut) : base(screwNut)
        {
        }

        public ObservableCollection<BaseValveWithScrewNut> BaseValveWithScrewNuts { get; set; }

        public ObservableCollection<ScrewNutJournal> ScrewNutJournals { get; set; }
        public ObservableCollection<ScrewNutWithFile> Files { get; set; }
    }
}
