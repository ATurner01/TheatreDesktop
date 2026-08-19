using System.Windows.Controls;
using TheatreDesktop.ViewModel;

namespace TheatreDesktop.Views
{
    /// <summary>
    /// Interaction logic for Account.xaml
    /// </summary>
    public partial class Account : Page
    {
        public Account(AccountViewModel viewModel)
        {
            DataContext = viewModel;
            InitializeComponent();
        }
    }
}
