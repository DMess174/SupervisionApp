using System.Collections.Generic;

namespace DataLayer
{
    public class Customer : BaseTable
    {
        public string Name { get; set; }
        public string ShortName { get; set; }

        public IEnumerable<Specification> Specifications { get; set; }
    }
}
