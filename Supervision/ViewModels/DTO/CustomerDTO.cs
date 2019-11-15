using DataLayer;
using System.Collections.Generic;

namespace Supervision.ViewModels
{
    public class CustomerDTO : BasePropertyChanged
    {
        public CustomerDTO()
        {
        }

        public CustomerDTO(Customer item)
        {
            Id = item.Id;
            Name = item.Name;
            ShortName = item.ShortName;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }

        public List <SpecificationDTO> Specifications { get; set; }


    }
}
