using System.Collections.Generic;
using System.Collections.ObjectModel;
using DataLayer.Entities.AssemblyUnits;
using DataLayer.Journals.Detailing;

namespace DataLayer.Entities.Detailing
{
    public class AssemblyUnitSealing : BaseSealing
    {
        public AssemblyUnitSealing()
        {
        }
        public AssemblyUnitSealing(AssemblyUnitSealing sealing) : base(sealing)
        {

        }

        public ObservableCollection<BaseValveWithSealing> BaseValveWithSeals { get; set; }

        public ObservableCollection<AssemblyUnitSealingJournal> AssemblyUnitSealingJournals { get; set; }
    }
}
