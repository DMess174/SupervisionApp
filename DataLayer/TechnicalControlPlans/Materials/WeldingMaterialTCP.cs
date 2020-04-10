using DataLayer.Journals.Materials;
using System.Collections.ObjectModel;

namespace DataLayer.TechnicalControlPlans.Materials
{
    public class WeldingMaterialTCP : BaseTCP
    {
        public ObservableCollection<WeldingMaterialJournal> WeldingMaterialJournals { get; set; }
    }
}
