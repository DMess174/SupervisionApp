using BusinessLayer.Repository.Interfaces.Entities.Material;
using DataLayer;
using DataLayer.Entities.Materials;
using DataLayer.Journals.Materials;
using DataLayer.TechnicalControlPlans.Materials;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BusinessLayer.Repository.Implementations.Entities.Material
{
    public class SheetMaterialRepository : RepositoryWithJournal<SheetMaterial, SheetMaterialJournal, MetalMaterialTCP>, ISheetMaterialRepository
    {
        public SheetMaterialRepository(DataContext context) : base(context) { }

        
    }
}
