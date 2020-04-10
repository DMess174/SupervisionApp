using DataLayer.Journals.Materials.AnticorrosiveCoating;
using System.Collections.ObjectModel;

namespace DataLayer.Entities.Materials.AnticorrosiveCoating
{
    public class Undercoat : BaseAnticorrosiveCoating
    {
        public ObservableCollection<UndercoatJournal> UndercoatJournals { get; set; }

        public Undercoat()
        {
        }

        public Undercoat(Undercoat coating) : base(coating)
        {

        }
    }
}
