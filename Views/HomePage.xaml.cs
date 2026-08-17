using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TheatreDesktop.ViewModel;
using TheatreDesktop.Services;

namespace TheatreDesktop
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        public HomePage()
        {
            string path = "temp";
            var dialogService = new DialogService();
            var applicationService = new ApplicationService();
            DataContext = new HomePageViewModel(applicationService, dialogService, path);
            InitializeComponent();
        }
        private void OnMovieClick(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("Views/Movies.xaml", UriKind.Relative));
        }
        private void OnAccountClick(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("Views/Account.xaml", UriKind.Relative));
        }
    }
}
