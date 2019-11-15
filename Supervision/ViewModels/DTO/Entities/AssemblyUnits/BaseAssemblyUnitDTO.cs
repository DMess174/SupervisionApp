using DataLayer;
using DataLayer.Entities.AssemblyUnits;

namespace Supervision.ViewModels.DTO.Entities.AssemblyUnits
{
    public class BaseAssemblyUnitDTO : BasePropertyChanged
    {
        public BaseAssemblyUnitDTO()
        {
        }

        public BaseAssemblyUnitDTO(BaseAssemblyUnit item)
        {
            Id = item.Id;
            Number = item.Number;
            Drawing = item.Drawing;
            Status = item.Status;
            PIDId = item.PIDId;
        }

        public int Id { get; set; }

        public string Number { get; set; }
     
        public string Drawing { get; set; }

        public string Status { get; set; }

        public int? PIDId { get; set; }
    }
}
