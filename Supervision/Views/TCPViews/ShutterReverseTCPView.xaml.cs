using Supervision.ViewModels.TCPViewModels;
using System.Windows.Controls;

namespace Supervision.Views.TCPViews
{
    /// <summary>
    /// Логика взаимодействия для Inspector.xaml
    /// </summary>
    public partial class ShutterReverseTCPView : Page
    {
        public ShutterReverseTCPView()
        {
            InitializeComponent();
            DataContext = new ShutterReverseTCPViewModel();
        }
    }
}
