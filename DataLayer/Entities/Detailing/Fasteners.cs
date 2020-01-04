namespace DataLayer.Entities.Detailing
{
    public class Fasteners : BaseDetail
    {
        public string Batch { get; set; }

        public int Amount { get; set; }

        public int? AmountRemaining { get; set; }
    }
}
