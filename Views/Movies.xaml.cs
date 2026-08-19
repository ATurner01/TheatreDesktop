using System.Windows.Controls;
using TheatreDesktop.ViewModel;

namespace TheatreDesktop.Views
{
    /// <summary>
    /// Interaction logic for Movies.xaml
    /// </summary>
    public partial class Movies : Page
    {
        public Movies(MovieViewModel viewModel)
        {
            DataContext = viewModel;
            InitializeComponent();
        }
    }
}
