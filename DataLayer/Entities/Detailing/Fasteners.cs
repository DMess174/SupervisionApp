namespace DataLayer.Entities.Detailing
{
    public class Fasteners : BaseDetail
    {
        public string Thread { get; set; }

        public string Hardness { get; set; }

        public string Batch { get; set; }

        public int Amount { get; set; }

        public int? AmountRemaining { get; set; }

        public Fasteners()
        {

        }

        public Fasteners(Fasteners fastener) : base(fastener)
        {

        }
    }
}
