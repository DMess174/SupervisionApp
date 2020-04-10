using DataLayer.Journals.Periodical;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DataLayer.TechnicalControlPlans.Periodical
{
    public class CoatingPorosityTCP : BaseTCP
    {
        public ObservableCollection<CoatingPorosityJournal> CoatingPorosityJournals { get; set; }
    }
}
