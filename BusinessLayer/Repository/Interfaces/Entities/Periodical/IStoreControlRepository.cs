using DataLayer.Journals.Materials;
using System;

namespace BusinessLayer.Repository.Interfaces.Entities
{
    public interface IStoreControlRepository : IRepository<StoresControlJournal>
    {
        DateTime GetLastDateControl();
    }
}
