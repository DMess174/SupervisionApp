using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Entities.Detailing
{
    public class BaseSealing : BaseEntity
    {
        public BaseSealing() { }
        public BaseSealing(BaseSealing sealing) : base(sealing)
        {
            Material = sealing.Material;
            Batch = sealing.Batch;
            Series = sealing.Series;
        }

        public string Material { get; set; }

        public string Batch { get; set; }

        public string Series { get; set; }

        public int Amount { get; set; }

        public int? AmountRemaining { get; set; }

        [NotMapped]
        public new string FullName => string.Format($"{Certificate} - {Batch} - {Series}/{Status}/{Name} {Drawing}");
    }
}
