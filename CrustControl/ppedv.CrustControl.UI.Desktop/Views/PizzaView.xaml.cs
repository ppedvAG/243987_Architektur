using Microsoft.Extensions.DependencyInjection;
using ppedv.CrustControl.UI.Desktop.ViewModels;
using System.Windows.Controls;

namespace ppedv.CrustControl.UI.Desktop.Views
{
    /// <summary>
    /// Interaction logic for PizzaView.xaml
    /// </summary>
    public partial class PizzaView : UserControl
    {
        public PizzaView()
        {
            InitializeComponent();
            DataContext = App.Current.Services.GetService<PizzaViewModel>();
        }
    }
}
