using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Entities
{
    public class BaseEntity : BaseTable
    {
        public string Name { get; set; }

        public string Number { get; set; }

        public string Drawing { get; set; }

        public string Certificate { get; set; }

        public string Status { get; set; }

        public string Comment { get; set; }

        [NotMapped]
        public string FullName => string.Format($"{Number} - {Status}");

        public BaseEntity()
        {

        }

        public BaseEntity(BaseEntity entity)
        {
            Name = entity.Name;
            Number = entity.Number;
            Drawing = entity.Drawing;
            Certificate = entity.Certificate;
            Status = entity.Status;
            Comment = entity.Comment;
        }
    }
}
