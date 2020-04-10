using DataLayer.Journals.Materials.AnticorrosiveCoating;
using System.Collections.ObjectModel;

namespace DataLayer.Entities.Materials.AnticorrosiveCoating
{
    public class AbrasiveMaterial : BaseAnticorrosiveCoating
    {
        public ObservableCollection<AbrasiveMaterialJournal> AbrasiveMaterialJournals { get; set; }

        public AbrasiveMaterial()
        {
        }

        public AbrasiveMaterial(AbrasiveMaterial coating) : base(coating)
        {

        }
    }
}
