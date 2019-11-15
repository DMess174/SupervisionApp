using DataLayer;
using System.Collections.Generic;

namespace Supervision.ViewModels
{
    public class ProductTypeDTO : BasePropertyChanged
    {
        public ProductTypeDTO()
        {
        }

        public ProductTypeDTO(ProductType item)
        {
            Id = item.Id;
            Name = item.Name;
            ShortName = item.ShortName;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }

        public List <PIDDTO> PIDs { get; set; }

    }
}
