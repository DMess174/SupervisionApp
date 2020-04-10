using DataLayer.Journals;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DataLayer.TechnicalControlPlans
{
    public class FactoryInspectionTCP : BaseTCP
    {
        public ObservableCollection<FactoryInspectionJournal> FactoryIspectionJournals { get; set; }
    }
}
