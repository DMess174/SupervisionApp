using System;
using BusinessLayer.Repository.Interfaces;
using DataLayer;

namespace Supervision.ViewModels.EntityViewModels
{
    public class BaseVM : BasePropertyChanged
    {
        protected readonly IUnitOfWorkFactory unitOfWorkFactory;

        public BaseVM(IUnitOfWorkFactory UnitOfWorkFactory)
        {
            unitOfWorkFactory = UnitOfWorkFactory ?? throw new ArgumentNullException(nameof(UnitOfWorkFactory));
        }
    }
}