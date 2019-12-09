namespace DataLayer.Entities.Detailing
{
    public class BaseValveCover : BaseEntity
    {
        public int? SpindleId { get; set; }
        public Spindle Spindle { get; set; }

        public int? RunningSleeveId { get; set; }
        public RunningSleeve RunningSleeve { get; set; }
    }
}
