using System.Windows.Navigation;
using System.Windows.Controls;
using TheatreDesktop.Views;
using TheatreDesktop.Services;

namespace TheatreDesktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : NavigationWindow, INavigationHost
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void Navigate(Page page)
        {
            base.Navigate(page);
        }
    }
}