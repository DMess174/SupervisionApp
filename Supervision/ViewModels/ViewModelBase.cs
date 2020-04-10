using DataLayer;
using Supervision.Commands;
using System.Windows;
using System.Windows.Input;

namespace Supervision.ViewModels
{
    public abstract class ViewModelBase : BasePropertyChanged
    {
        private bool isBusy;
        public bool IsBusy
        {
            get => isBusy;
            protected set
            {
                isBusy = value;
                RaisePropertyChanged();
            }
        }

        public ICommand CloseWindowCommand { get; protected set; }
        protected virtual void CloseWindow(object obj)
        {
            Window w = obj as Window;
            w?.Close();
        }


        public ViewModelBase()
        {
            CloseWindowCommand = new Command(o => CloseWindow(o));
        }
    }
}
