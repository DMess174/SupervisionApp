using DataLayer.Files;
using DataLayer.Journals.AssemblyUnits;
using System.Collections.ObjectModel;

namespace DataLayer.Entities.AssemblyUnits
{
    public class BaseAssemblyUnit : BaseEntity
    {
        public BaseAssemblyUnit()
        {
        }
        public BaseAssemblyUnit(BaseAssemblyUnit unit) : base(unit)
        {

        }

        public string AutoNumber { get; set; }

        public int? PIDId { get; set; }
        public PID PID { get; set; }

        public ObservableCollection<CoatingJournal> CoatingJournals { get; set; }
        public ObservableCollection<BaseAssemblyUnitWithFile> Files { get; set; }
    }
}
