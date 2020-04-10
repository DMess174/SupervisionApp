using BusinessLayer.Repository.Implementations;
using DataLayer.Entities.Materials;
using DataLayer.Journals.Materials;
using DataLayer.TechnicalControlPlans.Materials;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Repository.Interfaces.Entities.Material
{
    public interface ISheetMaterialRepository : IRepository<SheetMaterial>, IRepositoryWithJournal<SheetMaterial, SheetMaterialJournal, MetalMaterialTCP>
    {
        Task<SheetMaterial> GetByIdIncludeAsync(int id);
    }
}
