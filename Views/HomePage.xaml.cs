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

namespace TheatreDesktop
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        protected HomePageViewModel ViewModel { get; set; }
        public HomePage()
        {
            string path = "temp";
            ViewModel = new HomePageViewModel(path);
            ViewModel.RequestClose += delegate { OnClose(); };
            DataContext = ViewModel;
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
        private static void OnClose()
        {
            var result = MessageBox.Show(
                "Are you sure you want to exit?",
                "Confirm Exit",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }
    }
}
