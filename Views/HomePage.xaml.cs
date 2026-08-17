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

namespace TheatreDesktop.Views
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
            var navigationService = new NavigationServiceHelper(this);
            DataContext = new HomePageViewModel(applicationService, dialogService, navigationService, path);
            InitializeComponent();
        }
    }
}
