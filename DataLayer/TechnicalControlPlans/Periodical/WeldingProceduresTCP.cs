using DataLayer.Journals.Periodical;
using System.Collections.ObjectModel;

namespace DataLayer.TechnicalControlPlans.Periodical
{
    public class WeldingProceduresTCP : BaseTCP
    {
        public ObservableCollection<WeldingProceduresJournal> WeldingProceduresJournals { get; set; }
    }
}
