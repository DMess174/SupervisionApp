using DataLayer;
using DataLayer.Entities.AssemblyUnits;
using Supervision.ViewModels.DTO.Entities.AssemblyUnits;
using System;
using System.Collections.Generic;

namespace Supervision.ViewModels
{
    public class PIDDTO : BasePropertyChanged
    {
        public PIDDTO()
        {
        }

        public PIDDTO(PID item)
        {
            Id = item.Id;
            Number = item.Number;
            Amount = item.Amount;
            DN = item.DN;
            PN = item.PN;
            ConnectionType = item.ConnectionType;
            EarthquakeResistance = item.EarthquakeResistance;
            Climatic = item.Climatic;
            DriveType = item.DriveType;
            TechDocumentation = item.TechDocumentation;
            ShippingDate = item.ShippingDate;
            SpecificationId = item.SpecificationId;
            ProductTypeId = item.ProductTypeId;
        }

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

        public List <ShutterReverseDTO> ShutterReverses{ get; set; }
    }
}
