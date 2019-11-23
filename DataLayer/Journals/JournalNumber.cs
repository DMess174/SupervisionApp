using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Journals
{
    public class JournalNumber : BasePropertyChanged
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public bool IsHidden { get; set; }
    }
}
