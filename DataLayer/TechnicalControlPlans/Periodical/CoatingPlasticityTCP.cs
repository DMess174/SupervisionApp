using DataLayer.Journals.Periodical;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DataLayer.TechnicalControlPlans.Periodical
{
    public class CoatingPlasticityTCP : BaseTCP
    {
        public ObservableCollection<CoatingPlasticityJournal> CoatingPlasticityJournals { get; set; }
    }
}
