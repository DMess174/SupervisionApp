using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.TechnicalControlPlans
{
    public class BaseTCP : BaseTable
    {
        public string Point { get; set; }
        public string OperationName { get; set; }
        public string Description { get; set; }

        public int? OperationNameId { get; set; }
        [ForeignKey("OperationNameId")]
        public OperationType OperationType { get; set; }
    }
}