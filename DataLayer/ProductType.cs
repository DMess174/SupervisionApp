using DataLayer.Journals;
using DataLayer.TechnicalControlPlans;
using System.Collections.Generic;

namespace DataLayer
{
    public class ProductType : BaseTable
    {
        public string Name { get; set; }
        public string ShortName { get; set; }

        public IEnumerable<PID> PIDs { get; set; }
        public IEnumerable<BaseTCP> BaseTCPs { get; set; }
    }
}
