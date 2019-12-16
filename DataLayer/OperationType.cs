using DataLayer.TechnicalControlPlans;
using System.Collections.Generic;

namespace DataLayer
{
    public class OperationType : BaseTable
    {
        public string Name { get; set; }

        public IEnumerable<BaseTCP> BaseTCPs { get; set; }
    }
}
