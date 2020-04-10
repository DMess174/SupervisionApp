using DataLayer.Entities.Periodical;
using DataLayer.TechnicalControlPlans.Periodical;

namespace DataLayer.Journals.Periodical
{
    public class WeldingProceduresJournal : BaseJournal<WeldingProcedures, WeldingProceduresTCP>
    {
        public WeldingProceduresJournal() { }

        public WeldingProceduresJournal(WeldingProcedures entity, WeldingProceduresTCP entityTCP) : base(entity, entityTCP)
        { }

        public WeldingProceduresJournal(int id, WeldingProceduresJournal journal) : base(id, journal)
        { }
    }
}
