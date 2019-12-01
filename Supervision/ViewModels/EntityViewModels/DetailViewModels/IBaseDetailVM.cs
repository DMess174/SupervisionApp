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
