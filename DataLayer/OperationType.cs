using DataLayer.TechnicalControlPlans;
using System.Collections.ObjectModel;

namespace DataLayer
{
    public class OperationType : BaseTable
    {
        public string Name { get; set; }

        public ObservableCollection<BaseTCP> BaseTCPs { get; set; }
    }
}
