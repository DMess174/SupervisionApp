using DataLayer.Journals.Detailing;
using System.Collections.Generic;
using DataLayer.Entities.AssemblyUnits;
using System.Collections.ObjectModel;
using DataLayer.Files;

namespace DataLayer.Entities.Detailing
{
    public class BallValve : BaseEntity
    {
        public string Material { get; set; }
        public string Diameter { get; set; }
        public string Pressure { get; set; }
        public string Designation { get; set; }

        public BallValve()
        {
            Name = "Кран шаровой";
        }

        public BallValve(BallValve valve) : base(valve)
        {
            Material = valve.Material;
            Diameter = valve.Diameter;
            Pressure = valve.Pressure;
            Designation = valve.Designation;
        }

        public int? BaseValveId { get; set; }
        public BaseValve BaseValve { get; set; }

        public ObservableCollection<BallValveJournal> BallValveJournals { get; set; }
        public ObservableCollection<BallValvesWithFile> Files { get; set; }
    }
}
