namespace DataLayer.Entities.AssemblyUnits
{
    public class BaseAssemblyUnit : BaseEntity
    {
        public int? PIDId { get; set; }
        public PID PID { get; set; }
    }
}
