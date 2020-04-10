namespace DataLayer.Entities.Detailing
{
    public class SaddleWithSealing : BaseTable
    {
        public int SaddleId { get; set; }
        public Saddle Saddle { get; set; }

        public int FrontalSaddleSealingId { get; set; }
        public FrontalSaddleSealing FrontalSaddleSealing { get; set; }
    }
}
