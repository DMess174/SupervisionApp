using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Supervision.ViewModels.EntityViewModels.DetailViewModels
{
    public interface IBaseDetailVM
    {
        ICommand CloseWindow();
        ICommand EditItem();
        ICommand AddItem();
        ICommand RemoveItem();
    }
}
