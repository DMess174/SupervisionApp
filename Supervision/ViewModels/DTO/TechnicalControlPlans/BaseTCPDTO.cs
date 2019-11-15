using DataLayer;
using DataLayer.TechnicalControlPlans;

namespace Supervision.ViewModels.DTO.TechnicalControlPlans
{
    public class BaseTCPDTO : BasePropertyChanged
    {
        public BaseTCPDTO()
        {
        }

        public BaseTCPDTO(BaseTCP item)
        {
            Id = item.Id;
            Point = item.Point;
            OperationName = item.OperationName;
            Description = item.Description;
        }

        public int Id { get; set; }
        public string Point { get; set; }
        public string OperationName { get; set; }
        public string Description { get; set; }
    }
}
