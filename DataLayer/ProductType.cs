using DataLayer.Entities.Periodical;
using DataLayer.TechnicalControlPlans;
using System.Collections.ObjectModel;

namespace DataLayer
{
    public class ProductType : BaseTable
    {
        public string Name { get; set; }
        public string ShortName { get; set; }

        public ObservableCollection<PID> PIDs { get; set; }
        public ObservableCollection<BaseTCP> BaseTCPs { get; set; }
        public ObservableCollection<WeldingProcedures> WeldingProcedures { get; set; }
        public ObservableCollection<NDTControl> NDTControls { get; set; }
    }
}
