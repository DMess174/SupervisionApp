using DataLayer;
using DataLayer.Entities.Detailing;

namespace Supervision.ViewModels.DTO.Entities.Detailing
{
    public class BaseDetailDTO : BasePropertyChanged
    {
        public BaseDetailDTO()
        {
        }

        public BaseDetailDTO(BaseDetail item)
        {
            Id = item.Id;
            Number = item.Number;
            Drawing = item.Drawing;
            Material = item.Material;
            Certificate = item.Certificate;
            Melt = item.Melt;
            Status = item.Status;
        }

        public int Id { get; set; }

        public string Number { get; set; }

        public string Drawing { get; set; }

        public string Material { get; set; }

        public string Certificate { get; set; }

        public string Melt { get; set; }

        public string Status { get; set; }
    }
}
