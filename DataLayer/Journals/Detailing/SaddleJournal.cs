using DataLayer.Entities.Detailing;
using DataLayer.TechnicalControlPlans.Detailing;

namespace DataLayer.Journals.Detailing
{
    public class SaddleJournal : BaseJournal<Saddle, SaddleTCP>
    {
        public SaddleJournal() { }

        public SaddleJournal(Saddle entity, SaddleTCP entityTCP) : base(entity, entityTCP)
        { }

        public SaddleJournal(int id, SaddleJournal journal) : base(id, journal)
        { }
    }
}
