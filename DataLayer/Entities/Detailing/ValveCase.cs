using DataLayer.Entities.AssemblyUnits;
using DataLayer.Journals.Detailing;
using DataLayer.TechnicalControlPlans.Detailing;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Entities.Detailing
{
    public class ValveCase : BaseCastingCase
    {
        public ValveCase() : base()
        {
            Name = "Корпус ЗШ";
        }

        public List<ValveCaseJournal> ValveCaseJournals{ get; set; }
        [NotMapped]
        public List<ValveCaseTCP> ValveCaseTCPs{ get; set; }
    }
}
