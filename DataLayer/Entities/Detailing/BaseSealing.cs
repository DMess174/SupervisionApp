namespace DataLayer.Entities.Detailing
{
    public class BaseSealing : BaseEntity
    {
        public string Material { get; set; }

        public string Batch { get; set; }

        public string Series { get; set; }

        public int Amount { get; set; }

        public int? AmountRemaining { get; set; }
    }
}
