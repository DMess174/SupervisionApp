using DataLayer.Entities.AssemblyUnits;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Entities.Materials.AnticorrosiveCoating
{
    public class BaseAnticorrosiveCoating : BaseTable
    {
        public string Name { get; set; }
        public string Certificate { get; set; }
        public string Batch { get; set; }
        public string Amount { get; set; }
        public string Status { get; set; }
        public string Comment { get; set; }

        [NotMapped] 
        public string FullName => string.Format($"{Batch}/{Name}");

        public IEnumerable<BaseValveWithCoating> BaseValveWithCoatings { get; set; }
        public IEnumerable<ReverseShutterWithCoating> ReverseShutterWithCoatings { get; set; }
    }
}
