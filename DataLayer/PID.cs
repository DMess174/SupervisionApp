using DataLayer.Entities.AssemblyUnits;
using System;
using System.Collections.Generic;

namespace DataLayer
{
    public class PID : BasePropertyChanged
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Amount { get; set; }
        public string DN { get; set; }
        public string PN { get; set; }
        public string ConnectionType { get; set; }
        public string EarthquakeResistance { get; set; }
        public string Climatic { get; set; }
        public string DriveType { get; set; }
        public string TechDocumentation { get; set; }
        public DateTime? ShippingDate { get; set; }
        public int? SpecificationId { get; set; }
        public int? ProductTypeId { get; set; }

        public List <ShutterReverse> ShutterReverses{ get; set; }
    }
}
