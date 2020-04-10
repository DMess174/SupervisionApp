using DataLayer.Entities.Detailing;
using DataLayer.Entities.Detailing.CompactGateValveDetails;
using DataLayer.Entities.Detailing.ReverseShutterDetails;
using DataLayer.Entities.Detailing.WeldGateValveDetails;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Entities.Materials
{
    public class MetalMaterial : BaseTable
    {
        public MetalMaterial() { Status = "Годен"; }

        public MetalMaterial(MetalMaterial material)
        {
            Name = material.Name;
            Batch = material.Batch;
            Certificate = material.Certificate;
            Comment = material.Comment;
            FirstSize = material.FirstSize;
            Material = material.Material;
            MaterialCertificateNumber = material.MaterialCertificateNumber;
            Melt = material.Melt;
            Number = Microsoft.VisualBasic.Interaction.InputBox("Введите номер:");
            SecondSize = material.SecondSize;
            Status = material.Status;
            ThirdSize = material.ThirdSize;
        }

        public string Name { get; set; }
        public string Number { get; set; }
        public string Material { get; set; }
        public string Melt { get; set; }
        public string Certificate { get; set; }
        public string Batch { get; set; }
        public string MaterialCertificateNumber { get; set; }
        public string Status { get; set; }
        public string FirstSize { get; set; }
        public string SecondSize { get; set; }
        public string ThirdSize { get; set; }
        public string Comment { get; set; }

        [NotMapped] 
        public string FullName => string.Format($"{Number}/{Material}/{Melt}/{Name}");

        public ObservableCollection<Spindle> Spindles { get; set; }
        public ObservableCollection<Saddle> Saddles { get; set; }
        public ObservableCollection<Nozzle> Nozzles { get; set; }
        public ObservableCollection<Gate> Gates { get; set; }
        public ObservableCollection<WeldNozzle> WeldNozzles { get; set; }
        public ObservableCollection<SideWall> SideWalls { get; set; }
        public ObservableCollection<FrontWall> FrontWalls { get; set; }
        public ObservableCollection<CoverSleeve> CoverSleeves { get; set; }
        public ObservableCollection<CoverFlange> CoverFlanges { get; set; }
        public ObservableCollection<CaseFlange> CaseFlanges { get; set; }
        public ObservableCollection<CaseBottom> CaseBottoms { get; set; }
        public ObservableCollection<BronzeSleeveShutter> BronzeSleeveShutters { get; set; }
        public ObservableCollection<ShaftShutter> ShaftShutters { get; set; }
        public ObservableCollection<SteelSleeveShutter> SteelSleeveShutters { get; set; }
        public ObservableCollection<StubShutter> StubShutters { get; set; }
        public ObservableCollection<ShutterDisk> ShutterDisks { get; set; }
        public ObservableCollection<ShutterGuide> ShutterGuides { get; set; }
        public ObservableCollection<CounterFlange> CounterFlanges { get; set; }
        public ObservableCollection<CoverSealingRing> CoverSealingRings { get; set; }
        public ObservableCollection<CaseEdge> CaseEdges { get; set; }
    }
}
