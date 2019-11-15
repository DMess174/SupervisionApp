using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities
{
    public class BaseEntity : BasePropertyChanged
    {
        public int Id { get; set; }

        public string Number { get; set; }

        public string Drawing { get; set; }

        public string Status { get; set; }

        public string Name { get; set; }
    }
}
