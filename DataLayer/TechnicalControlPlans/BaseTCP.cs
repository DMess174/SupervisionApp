namespace DataLayer.TechnicalControlPlans
{
    public class BaseTCP : BasePropertyChanged
    {
        public int Id { get; set; }
        public string Point { get; set; }
        public string OperationName { get; set; }
        public string Description { get; set; }
    }
}
