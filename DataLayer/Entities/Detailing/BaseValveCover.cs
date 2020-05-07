using DataLayer.Files;
using System.Collections.ObjectModel;

namespace DataLayer.Entities.Detailing
{
    public class BaseValveCover : BaseEntity
    {
        public int? SpindleId { get; set; }
        public Spindle Spindle { get; set; }

        public int? RunningSleeveId { get; set; }
        public RunningSleeve RunningSleeve { get; set; }

        public ObservableCollection<BaseValveCoverWithFile> Files { get; set; }

        public BaseValveCover()
        {
        }

        public BaseValveCover(BaseValveCover cover) : base(cover)
        {

        }
    }
}
