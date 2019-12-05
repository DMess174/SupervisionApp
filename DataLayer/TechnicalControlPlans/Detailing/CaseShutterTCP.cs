﻿using DataLayer.Entities.Detailing;
using DataLayer.Journals.Detailing;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.TechnicalControlPlans.Detailing
{
    public class CaseShutterTCP : BaseTCP
    {
        public List<CaseShutterJournal> CaseShutterJournals { get; set; }

        [NotMapped]
        public List<ShutterCase> CaseShutters { get; set; }
    }
}
