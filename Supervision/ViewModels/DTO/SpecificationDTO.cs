using DataLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Supervision.ViewModels
{
    public class SpecificationDTO : BasePropertyChanged
    {
        public SpecificationDTO()
        {
        }

        public SpecificationDTO(Specification item)
        {
            Id = item.Id;
            Number = item.Number;
            Program = item.Program;
            Consignee = item.Consignee;
            Facility = item.Facility;
            CustomerId = item.CustomerId;
        }

        public int Id { get; set; }
        public string Number { get; set; }
        public string Program { get; set; }
        public string Consignee { get; set; }
        public string Facility { get; set; }
        public int? CustomerId { get; set; }

        public List <PIDDTO> PIDs { get; set; }


    }
}
