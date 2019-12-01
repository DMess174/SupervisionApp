using Supervision.ViewModels;
using System.Windows.Controls;

namespace Supervision.Views.EntityViews
{
    /// <summary>
    /// Логика взаимодействия для Inspector.xaml
    /// </summary>
    public partial class ProductTypeView : Page
    {
        public ProductTypeView()
        {
            InitializeComponent();
            DataContext = new ProductTypeViewModel();
        }
    }
}
