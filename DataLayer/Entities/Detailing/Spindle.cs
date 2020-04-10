using DataLayer.Journals.Detailing;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DataLayer.Entities.Detailing
{
    public class Spindle : ValveCoverAssemblyDetail
    {
        public Spindle()
        {
            Name = "Шпиндель";
        }

        public Spindle(Spindle spindle) : base(spindle)
        {
        }

        public ObservableCollection<SpindleJournal> SpindleJournals { get; set; }
    }
}
