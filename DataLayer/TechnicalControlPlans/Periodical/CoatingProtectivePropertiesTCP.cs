using DataLayer.Journals.Periodical;
using System.Collections.ObjectModel;

namespace DataLayer.TechnicalControlPlans.Periodical
{
    public class CoatingProtectivePropertiesTCP : BaseTCP
    {
        public ObservableCollection<CoatingProtectivePropertiesJournal> CoatingProtectivePropertiesJournals { get; set; }
    }
}
