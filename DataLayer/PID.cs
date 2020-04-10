using DataLayer.Entities.AssemblyUnits;
using DataLayer.Entities.Detailing;
using DataLayer.Journals;
using System;
using System.Collections.ObjectModel;

namespace DataLayer
{
    public class PID : BaseTable
    {
        public string Number { get; set; }
        public int? Amount { get; set; }
        public int? AmountShipped { get; set; }
        public string DN { get; set; }
        public string PN { get; set; }
        public string ConnectionType { get; set; }
        public string EarthquakeResistance { get; set; }
        public string Climatic { get; set; }
        public string DriveType { get; set; }
        public string Consignee { get; set; }
        public string TechDocumentation { get; set; }
        public DateTime? ShippingDate { get; set; }
        public string Designation { get; set; }
        public string Purpose { get; set; }
        public int? Weight { get; set; }
        public string Description { get; set; }
        public string Comment { get; set; }

        public string STD1 { get; set; }
        public string STD2 { get; set; }

        public int? SpecificationId { get; set; }
        public Specification Specification { get; set; }

        public int? ProductTypeId { get; set; }
        public ProductType ProductType { get; set; }

        public ObservableCollection<BaseAssemblyUnit> BaseAssemblyUnits { get; set; }
        public ObservableCollection<Gate> Gates { get; set; }
        public ObservableCollection<PIDJournal> PIDJournals { get; set; }

        public PID()
        {
        }

        public PID(Specification specification)
        {
            SpecificationId = specification.Id;
        }
    }
}
