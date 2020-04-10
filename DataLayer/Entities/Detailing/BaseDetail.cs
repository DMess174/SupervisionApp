namespace DataLayer.Entities.Detailing
{
    public class BaseDetail : BaseEntity
    {
        public string Material { get; set; }

        public string Melt { get; set; }

        public BaseDetail()
        {
        }

        public BaseDetail(BaseDetail detail) : base(detail)
        {
            Material = detail.Material;
            Melt = detail.Melt;
        }
    }
}
