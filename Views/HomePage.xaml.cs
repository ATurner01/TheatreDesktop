using System.Windows.Controls;
using TheatreDesktop.ViewModel;

namespace TheatreDesktop.Views
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        public HomePage(HomePageViewModel viewModel)
        {
            DataContext = viewModel;
            InitializeComponent();
        }
    }
}
