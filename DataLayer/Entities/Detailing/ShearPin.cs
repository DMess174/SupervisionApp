using DataLayer.Journals.Detailing;
using DataLayer.Entities.AssemblyUnits;
using System.Collections.ObjectModel;

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

        }

        public string Diameter { get; set; }
        public string TensileStrength { get; set; }

        public int? BaseValveId { get; set; }
        public BaseValve BaseValve { get; set; }

        public ObservableCollection<ShearPinJournal> ShearPinJournals { get; set; }
    }
}
