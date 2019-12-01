using System.Collections.Generic;

namespace DataLayer
{
    public class ProductType : BasePropertyChanged
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }

        public List<PID> PIDs { get; set; }

    }
}
