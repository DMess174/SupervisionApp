using DataLayer.Entities.Detailing.ReverseShutterDetails;
using DataLayer.Journals.Detailing.ReverseShutterDetails;
using DataLayer.TechnicalControlPlans.Detailing.ReverseShutterDetails;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Repository.Interfaces.Entities.Detailing
{
    public interface IBronzeSleeveShutterRepository : IRepositoryWithJournal<BronzeSleeveShutter,BronzeSleeveShutterJournal, BronzeSleeveShutterTCP>
    {
    }
}
