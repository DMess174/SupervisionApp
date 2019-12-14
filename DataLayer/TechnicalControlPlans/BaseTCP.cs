namespace DataLayer.TechnicalControlPlans
{
    public class BaseTCP : BaseTable
    {
        public string Point { get; set; }
        public string OperationName { get; set; }
        public string Description { get; set; }
    }
}
