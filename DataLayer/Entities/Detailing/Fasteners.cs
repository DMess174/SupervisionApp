namespace DataLayer.Entities.Detailing
{
    public class Fasteners : BaseEntity
    {
        public string Material { get; set; }

        public string Melt { get; set; }

        public string Batch { get; set; }

        public string Certificate { get; set; }

        public int? Amount { get; set; }

        public int? AmountUsed { get; set; } = 0;
    }
}
