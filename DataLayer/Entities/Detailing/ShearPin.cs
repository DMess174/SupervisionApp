using DataLayer.Journals.Detailing;
using DataLayer.Entities.AssemblyUnits;
using System.Collections.ObjectModel;
using DataLayer.Files;

namespace DataLayer.Entities.Detailing
{
    public class ShearPin : BaseDetail
    {
        public ShearPin()
        {
            Name = "Штифт срезной";
        }

        public ShearPin(ShearPin shearPin) : base(shearPin)
        {
            Diameter = shearPin.Diameter;
            TensileStrength = shearPin.TensileStrength;
        }

        public string Diameter { get; set; }
        public string TensileStrength { get; set; }

        public int? BaseValveId { get; set; }
        public BaseValve BaseValve { get; set; }

        public ObservableCollection<ShearPinJournal> ShearPinJournals { get; set; }
        public ObservableCollection<ShearPinWithFile> Files { get; set; }
    }
}
