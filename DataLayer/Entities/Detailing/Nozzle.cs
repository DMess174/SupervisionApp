using DataLayer.Journals.Detailing;
using DataLayer.TechnicalControlPlans.Detailing;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Entities.Detailing
{
    public class Nozzle : BaseDetail
    {
        public Nozzle() : base()
        {
            Name = "Катушка";
        }

        private string diameter;
        public string Diameter
        {
            get
            {
                return diameter;
            }
            set
            {
                diameter = value;
                RaisePropertyChanged("Diameter");
            }
        }

        private string thickness;
        public string Thickness
        {
            get
            {
                return thickness;
            }
            set
            {
                thickness = value;
                RaisePropertyChanged("Thickness");
            }
        }

        private string thicknessJoin;
        public string ThicknessJoin
        {
            get
            {
                return thicknessJoin;
            }
            set
            {
                thicknessJoin = value;
                RaisePropertyChanged("ThicknessJoin");
            }
        }


        public int? CastingCaseId { get; set; }
        public BaseCastingCase CastingCase { get; set; }

        public IEnumerable<NozzleJournal> NozzleJournals { get; set; }
        [NotMapped]
        public IEnumerable<NozzleTCP> NozzleTCPs{ get; set; }
    }
}
