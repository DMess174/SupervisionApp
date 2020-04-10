using DataLayer.Journals.Materials;
using System.Collections.ObjectModel;

namespace DataLayer.TechnicalControlPlans.Materials
{
    public class MetalMaterialTCP : BaseTCP
    {
        public ObservableCollection<SheetMaterialJournal> SheetMaterialJournals { get; set; }
        public ObservableCollection<ForgingMaterialJournal> ForgingMaterialJournals { get; set; }
        public ObservableCollection<RolledMaterialJournal> RolledMaterialJournals { get; set; }
    }
}
